using AI.API.Models;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Qdrant.Client.Grpc;

namespace AI.API.Services;

public class AiApiInitializer : IHostedService
{
    private readonly LeagueCache _cache;
    private readonly LeagueDataTools _tools;
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, League> _leagueCollection;
    private readonly QdrantCollection<Guid, Team> _teamCollection;
    private readonly QdrantCollection<Guid, Player> _playerCollection;
    private readonly QdrantCollection<Guid, Season> _seasonCollection;
    private readonly QdrantCollection<Guid, Standings> _standingsCollection;
    private readonly QdrantCollection<Guid, Game> _gamesCollection;
    private readonly QdrantCollection<Guid, BaseballStats> _baseballStatsCollection;
    private readonly QdrantCollection<Guid, BasketballStats> _basketballStatsCollection;
    private readonly QdrantCollection<Guid, FootballStats> _footballStatsCollection;


    public AiApiInitializer(
        LeagueCache cache,
        LeagueDataTools tools,
        IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, League> leagueCollection,
        QdrantCollection<Guid, Team> teamCollection,
        QdrantCollection<Guid, Player> playerCollection,
        QdrantCollection<Guid, Season> seasonCollection,
        QdrantCollection<Guid, Standings> standingsCollection,
        QdrantCollection<Guid, Game> gamesCollection,
        QdrantCollection<Guid, BaseballStats> baseballStatsCollection,
        QdrantCollection<Guid, BasketballStats> basketballStatsCollection,
        QdrantCollection<Guid, FootballStats> footballStatsCollection)
    {
        _cache = cache;
        _tools = tools;
        _embedding = embedding;
        _leagueCollection = leagueCollection;
        _teamCollection = teamCollection;
        _playerCollection = playerCollection;
        _seasonCollection = seasonCollection;
        _standingsCollection = standingsCollection;
        _gamesCollection = gamesCollection;
        _baseballStatsCollection = baseballStatsCollection;
        _basketballStatsCollection = basketballStatsCollection;
        _footballStatsCollection = footballStatsCollection;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Load data AFTER Aspire launches all services
        _cache.LeagueData = await _tools.GetLeagueData();

        await EnsureCollectionsAsync(cancellationToken);

        // Generate embeddings AFTER Azure OpenAI is reachable
        if(!await CollectionHasDataAsync(_leagueCollection, _embedding))
            await IngestLeaguesAsync();
        if (!await CollectionHasDataAsync(_teamCollection, _embedding))
            await IngestTeamsAsync();
        if (!await CollectionHasDataAsync(_playerCollection, _embedding))
            await IngestPlayersAsync();
        if (!await CollectionHasDataAsync(_seasonCollection, _embedding))
            await IngestSeasonsAsync();
        if (!await CollectionHasDataAsync(_standingsCollection, _embedding))
            await IngestStandingsAsync();
        if (!await CollectionHasDataAsync(_gamesCollection, _embedding))
            await IngestGamesAsync();
        if (!await CollectionHasDataAsync(_baseballStatsCollection, _embedding))
            await IngestBaseballStatsAsync();
        if (!await CollectionHasDataAsync(_basketballStatsCollection, _embedding))
            await IngestBasketballStatsAsync();
        if (!await CollectionHasDataAsync(_footballStatsCollection, _embedding))
            await IngestFootballStatsAsync();
    }

    // ------------------------------------------------------------
    // COLLECTION INITIALIZATION
    // ------------------------------------------------------------
    private async Task EnsureCollectionsAsync(CancellationToken cancellationToken)
    {
        // Ensure collections AFTER Qdrant is running
        await _leagueCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _teamCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _playerCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _seasonCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _standingsCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _gamesCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _baseballStatsCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _basketballStatsCollection.EnsureCollectionExistsAsync(cancellationToken);
        await _footballStatsCollection.EnsureCollectionExistsAsync(cancellationToken);
    }

    private async Task<bool> CollectionHasDataAsync<TKey, TValue>(QdrantCollection<TKey, TValue> collection,
        IEmbeddingGenerator<string, Embedding<float>> embedding)
        where TKey : notnull
        where TValue : class
    {
        var vector = await embedding.GenerateAsync("Check if collection has data");

        var enumerator = collection.SearchAsync(vector.Vector, 1).GetAsyncEnumerator();

        try
        {
            return await enumerator.MoveNextAsync();
        }
        finally
        {
            await enumerator.DisposeAsync();
        }
    }

    // ------------------------------------------------------------
    // LEAGUES
    // ------------------------------------------------------------
    private async Task IngestLeaguesAsync()
    {
        foreach (var league in _cache.LeagueData.Leagues)
        {
            var vector = new League
            {
                Id = league.Id,
                Name = league.Name,
                Sport = league.Sport,
                Description = league.Description,
                OwnerFirstName = league.OwnerFirstName,
                OwnerLastName = league.OwnerLastName,
                EmailAddress = league.EmailAddress,
                TotalGamesPerSeason = league.TotalGamesPerSeason,
                TotalPlayoffTeams = league.TotalPlayoffTeams,
                MinimumTotalTeamPlayers = league.MinimumTotalTeamPlayers,
                MaximumTotalTeamPlayers = league.MaximumTotalTeamPlayers
            };
            var embedding = await _embedding.GenerateAsync($"{vector.Name} {vector.Description}");
            vector.Vector = embedding.Vector;
            await _leagueCollection.UpsertAsync(vector);
        }
    }

    // ------------------------------------------------------------
    // TEAMS
    // ------------------------------------------------------------
    private async Task IngestTeamsAsync()
    {
        foreach (var team in _cache.LeagueData.Teams)
        {
            var vector = new Team
            {
                Id = team.Id,
                LeagueId = team.LeagueId.ToString(),
                LeagueName = _cache.LeagueData.Leagues.FirstOrDefault(l => l.Id == team.LeagueId)?.Name ?? string.Empty,
                TeamName = team.TeamName,
                Description = team.Description,
                TeamColor = team.TeamColor,
                ManagerFirstName = team.TeamManager.FirstName,
                ManagerLastName = team.TeamManager.LastName,
                ManagerEmailAddress = team.TeamManager.EmailAddress,
                City = team.TeamAddress.City,
                State = team.TeamAddress.State,
                Country = team.TeamAddress.Country,
                ZipCode = team.TeamAddress.ZipCode
            };
            var embeddingText = $@"
            Team: {vector.TeamName}
            League: {vector.LeagueName}
            Description: {vector.Description}
            Manager: {vector.ManagerFirstName} {vector.ManagerLastName}
            Address: {vector.City}, {vector.State}, {vector.Country}, {vector.ZipCode}
            ";
            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;
            await _teamCollection.UpsertAsync(vector);
        }
    }

    // ------------------------------------------------------------
    // PLAYERS
    // ------------------------------------------------------------
    private async Task IngestPlayersAsync()
    {
        foreach (var player in _cache.LeagueData.Players)
        {
            var league = _cache.LeagueData.Leagues.FirstOrDefault(l => l.Id == _cache.LeagueData.Teams.FirstOrDefault(t => t.Id == player.TeamId)?.LeagueId);
            var vector = new Player
            {
                Id = player.Id,
                TeamId = player.TeamId.ToString(),
                TeamName = _cache.LeagueData.Teams.FirstOrDefault(t => t.Id == player.TeamId)?.TeamName ?? string.Empty,
                LeagueName = league?.Name ?? string.Empty,
                Sport = league?.Sport ?? string.Empty,
                FirstName = player.FirstName,
                LastName = player.LastName,
                State = player.PlayerAddress.State,
                City = player.PlayerAddress.City,
                Country = player.PlayerAddress.Country,
                ZipCode = player.PlayerAddress.ZipCode,
                EmailAddress = player.PlayerDetail.EmailAddress,
                PhoneNumber = player.PlayerDetail.PhoneNumber,
                BirthDate = player.PlayerDetail.BirthDate,
                Height = player.PlayerDetail.Height,
                Weight = player.PlayerDetail.Weight,
                Position = player.PlayerDetail.Position,
                Number = player.PlayerDetail.Number,
                Description = player.Description
            };
            var embeddingText = $@"
            Player: {vector.FirstName} {vector.LastName}
            Team: {vector.TeamName}
            League: {vector.LeagueName}
            Sport: {vector.Sport}
            Position: {vector.Position}
            Number: {vector.Number}
            Birth Date: {vector.BirthDate:yyyy-MM-dd}
            Height: {vector.Height} inches
            Weight: {vector.Weight} lbs
            Location: {vector.City}, {vector.State}, {vector.Country} {vector.ZipCode}
            Email: {vector.EmailAddress}
            Phone: {vector.PhoneNumber}
            Description: {vector.Description}
            ";

            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;
            await _playerCollection.UpsertAsync(vector);
        }
    }

    // ------------------------------------------------------------
    // SEASONS
    // ------------------------------------------------------------
    private async Task IngestSeasonsAsync()
    {
        foreach (var season in _cache.LeagueData.Seasons)
        {
            var vector = new Season
            {
                Id = season.Id,
                Year = season.Year,
                Description = season.Description
            };
            var embeddingText = $@"
            Season Year: {vector.Year}
            Description: {vector.Description}
            ";


            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;
            await _seasonCollection.UpsertAsync(vector);
        }
    }

    // ------------------------------------------------------------
    // STANDINGS
    // ------------------------------------------------------------
    private async Task IngestStandingsAsync()
    {
        foreach (var standings in _cache.LeagueData.Standings)
        {
            var league = _cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == standings.LeagueId);
            var team = _cache.LeagueData.Teams.FirstOrDefault(team => team.Id == standings.Team.Id);
            var season = _cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == standings.SeasonId);

            // Process the standings data
            var vector = new Standings
            {
                Id = standings.Id,
                LeagueId = standings.LeagueId.ToString(),
                LeagueName = league?.Name ?? string.Empty,
                Sport = league?.Sport ?? string.Empty,
                SeasonId = standings.SeasonId.ToString(),
                SeasonYear = season?.Year ?? 0,
                TeamId = standings.Team.Id.ToString(),
                TeamName = standings.Team.TeamName,
                ManagerFirstName = team?.TeamManager.FirstName ?? string.Empty,
                ManagerLastName = team?.TeamManager.LastName ?? string.Empty,
                State = team?.TeamAddress.State ?? string.Empty,
                City = team?.TeamAddress.City ?? string.Empty,
                Country = team?.TeamAddress.Country ?? string.Empty,
                ZipCode = team?.TeamAddress.ZipCode ?? string.Empty,
                GamesPlayed = standings.StandingsDetail.GamesPlayed,
                Wins = standings.StandingsDetail.Wins,
                Losses = standings.StandingsDetail.Losses,
                Ties = standings.StandingsDetail.Ties,
                PlayoffTeam = standings.StandingsDetail.PlayoffTeam,
                Champion = standings.StandingsDetail.Champion
            };

            var embeddingText = $@"
            Standings Record
            League: {vector.LeagueName}
            Sport: {vector.Sport}

            Season: {vector.SeasonYear}
            Team: {vector.TeamName}
            Manager: {vector.ManagerFirstName} {vector.ManagerLastName}

            Location: {vector.City}, {vector.State}, {vector.Country} {vector.ZipCode}

            Games Played: {vector.GamesPlayed}
            Wins: {vector.Wins}
            Losses: {vector.Losses}
            Ties: {vector.Ties}

            Playoff Team: {vector.PlayoffTeam}
            Champion: {vector.Champion}
            ";

            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;
            await _standingsCollection.UpsertAsync(vector);
        }

    }

    // ------------------------------------------------------------
    // GAMES
    // ------------------------------------------------------------
    private async Task IngestGamesAsync()
    {
        foreach (var game in _cache.LeagueData.Games)
        {
            var league = _cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == game.LeagueId);
            var season = _cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == game.SeasonId);

            var vector = new Game
            {
                Id = game.Id,
                LeagueId = game.LeagueId.ToString(),
                LeagueName = league?.Name ?? string.Empty,
                Sport = league?.Sport ?? string.Empty,
                SeasonId = game.SeasonId.ToString(),
                SeasonYear = season?.Year ?? 0,
                AwayTeamId = game.AwayTeam.Id.ToString(),
                AwayTeamName = game.AwayTeam.TeamName,
                HomeTeamId = game.HomeTeam.Id.ToString(),
                HomeTeamName = game.HomeTeam.TeamName,
                AwayTeamScore = game.GameDetail.AwayTeamScore,
                HomeTeamScore = game.GameDetail.HomeTeamScore,
                StartTime = game.GameDetail.StartTime,
                EndTime = game.GameDetail.EndTime,
                AwayInningRuns = game.GameDetail.AwayInningRuns,
                HomeInningRuns = game.GameDetail.HomeInningRuns,
                AwayTotalHits = game.GameDetail.AwayTotalHits,
                HomeTotalHits = game.GameDetail.HomeTotalHits
            };

            vector.GameStatus = game.GameStatus switch
            {
                GameStatus.NotStarted => "Not Started",
                GameStatus.InProgress => "In Progress",
                GameStatus.Completed => "Completed",
                GameStatus.Postponed => "Postponed",
                GameStatus.Delayed => "Delayed",
                _ => "Unknown"
            };

            if (game.WinningTeamId is not null)
            {
                vector.WinningTeamId = game.WinningTeamId.ToString();
                vector.WinningTeamName = game.WinningTeamId == game.AwayTeam.Id ? game.AwayTeam.TeamName : game.HomeTeam.TeamName;
            }

            var embeddingText = $@"
            Game Summary
            League: {vector.LeagueName}
            Sport: {vector.Sport}
            Season: {vector.SeasonYear}

            Home Team: {vector.HomeTeamName} ({vector.HomeTeamScore} runs, {vector.HomeTotalHits ?? 0} hits)
            Away Team: {vector.AwayTeamName} ({vector.AwayTeamScore} runs, {vector.AwayTotalHits ?? 0} hits)
            Winning Team: {vector.WinningTeamName}

            Game Status: {vector.GameStatus}

            Start Time: {vector.StartTime:yyyy-MM-dd HH:mm}
            End Time: {(vector.EndTime.HasValue ? vector.EndTime.Value.ToString("yyyy-MM-dd HH:mm") : "N/A")}

            Away Inning Runs: {(vector.AwayInningRuns != null ? string.Join(", ", vector.AwayInningRuns) : "N/A")}
            Home Inning Runs: {(vector.HomeInningRuns != null ? string.Join(", ", vector.HomeInningRuns) : "N/A")}
            ";

            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;

            await _gamesCollection.UpsertAsync(vector);
        }

    }

    // ------------------------------------------------------------
    // BASEBALL STATS
    // ------------------------------------------------------------
    private async Task IngestBaseballStatsAsync()
    {
        foreach(var stats in _cache.LeagueData.BaseballStats)
        {
            var league = _cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == stats.LeagueId);
            var season = _cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == stats.SeasonId);
            var game = _cache.LeagueData.Games.FirstOrDefault(game => game.Id == stats.GameId);
            var team = _cache.LeagueData.Teams.FirstOrDefault(team => team.Id == stats.TeamId);
            var player = _cache.LeagueData.Players.FirstOrDefault(player => player.Id == stats.PlayerId);

            var vector = new BaseballStats
            {
                Id = stats.Id,
                LeagueId = stats.LeagueId.ToString(),
                LeagueName = league?.Name ?? string.Empty,
                TeamId = stats.TeamId.ToString(),
                TeamName = team?.TeamName ?? string.Empty,
                PlayerId = stats.PlayerId.ToString(),
                FullName = $"{player?.FirstName} {player?.LastName}",
                SeasonId = stats.SeasonId.ToString(),
                SeasonYear = season?.Year ?? 0,
                GameId = stats.GameId.ToString(),
                AwayTeamId = game?.AwayTeam.Id.ToString(),
                AwayTeamName = game?.AwayTeam.TeamName ?? string.Empty,
                HomeTeamId = game?.HomeTeam.Id.ToString(),
                HomeTeamName = game?.HomeTeam.TeamName ?? string.Empty,
                AwayTeamScore = game?.GameDetail.AwayTeamScore ?? 0,
                HomeTeamScore = game?.GameDetail.HomeTeamScore ?? 0,
                AtBats = stats.HittingStats.AtBats,
                Hits = stats.HittingStats.Hits,
                TotalBases = stats.HittingStats.TotalBases,
                Runs = stats.HittingStats.Runs,
                Doubles = stats.HittingStats.Doubles,
                Triples = stats.HittingStats.Triples,
                HomeRuns = stats.HittingStats.HomeRuns,
                RunsBattedIn = stats.HittingStats.RunsBattedIn,
                StolenBases = stats.HittingStats.StolenBases,
                CaughtStealing = stats.HittingStats.CaughtStealing,
                Strikeouts = stats.HittingStats.Strikeouts,
                Walks = stats.HittingStats.Walks,
                HitByPitch = stats.HittingStats.HitByPitch,
                SacrificeFly = stats.HittingStats.SacrificeFly,
                Wins = stats.PitchingStats.Wins,
                Losses = stats.PitchingStats.Losses,
                PitchingRuns = stats.PitchingStats.Runs,
                Start = stats.PitchingStats.Start,
                Innings = (double)stats.PitchingStats.Innings,
                HitsAllowed = stats.PitchingStats.HitsAllowed,
                WalksAllowed = stats.PitchingStats.WalksAllowed,
                PitchingStrikeouts = stats.PitchingStats.PitchingStrikeouts
            };

            var embeddingText = $@"
            Baseball Stats
            League: {vector.LeagueName}
            Team: {vector.TeamName}
            Player: {vector.FullName}
            Season: {vector.SeasonYear}
            Game ID: {vector.GameId}

            Game Score
            Home Team: {vector.HomeTeamName} ({vector.HomeTeamScore})
            Away Team: {vector.AwayTeamName} ({vector.AwayTeamScore})

            Batting
            At Bats: {vector.AtBats}
            Hits: {vector.Hits}
            Total Bases: {vector.TotalBases}
            Runs: {vector.Runs}
            Doubles: {vector.Doubles}
            Triples: {vector.Triples}
            Home Runs: {vector.HomeRuns}
            RBIs: {vector.RunsBattedIn}
            Stolen Bases: {vector.StolenBases}
            Caught Stealing: {vector.CaughtStealing}
            Strikeouts: {vector.Strikeouts}
            Walks: {vector.Walks}
            Hit By Pitch: {vector.HitByPitch}
            Sacrifice Fly: {vector.SacrificeFly}

            Pitching
            Wins: {vector.Wins}
            Losses: {vector.Losses}
            Runs Allowed: {vector.PitchingRuns}
            Start: {vector.Start}
            Saves: {vector.Saves}
            Innings Pitched: {vector.Innings}
            Hits Allowed: {vector.HitsAllowed}
            Walks Allowed: {vector.WalksAllowed}
            Strikeouts: {vector.PitchingStrikeouts}
            ";

            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;

            await _baseballStatsCollection.UpsertAsync(vector);

        }
    }

    // ------------------------------------------------------------
    // BASKETBALL STATS
    // ------------------------------------------------------------
    private async Task IngestBasketballStatsAsync()
    {
        foreach (var stats in _cache.LeagueData.BasketballStats)
        {
            var league = _cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == stats.LeagueId);
            var season = _cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == stats.SeasonId);
            var game = _cache.LeagueData.Games.FirstOrDefault(game => game.Id == stats.GameId);
            var team = _cache.LeagueData.Teams.FirstOrDefault(team => team.Id == stats.TeamId);
            var player = _cache.LeagueData.Players.FirstOrDefault(player => player.Id == stats.PlayerId);

            var vector = new BasketballStats
            {
                Id = stats.Id,
                LeagueId = stats.LeagueId.ToString(),
                LeagueName = league?.Name ?? string.Empty,
                TeamId = stats.TeamId.ToString(),
                TeamName = team?.TeamName ?? string.Empty,
                PlayerId = stats.PlayerId.ToString(),
                FullName = $"{player?.FirstName} {player?.LastName}",
                SeasonId = stats.SeasonId.ToString(),
                SeasonYear = season?.Year ?? 0,
                GameId = stats.GameId.ToString(),
                AwayTeamId = game?.AwayTeam.Id.ToString(),
                AwayTeamName = game?.AwayTeam.TeamName ?? string.Empty,
                HomeTeamId = game?.HomeTeam.Id.ToString(),
                HomeTeamName = game?.HomeTeam.TeamName ?? string.Empty,
                AwayTeamScore = game?.GameDetail.AwayTeamScore ?? 0,
                HomeTeamScore = game?.GameDetail.HomeTeamScore ?? 0,
                Start = stats.Stats.Start,
                Minutes = stats.Stats.Minutes,
                Points = stats.Stats.Points,
                FieldGoalsMade = stats.Stats.FieldGoalsMade,
                FieldGoalsAttempted = stats.Stats.FieldGoalsAttempted,
                ThreePointersMade = stats.Stats.ThreePointersMade,
                ThreePointersAttempted = stats.Stats.ThreePointersAttempted,
                FreeThrowsMade = stats.Stats.FreeThrowsMade,
                FreeThrowsAttempted = stats.Stats.FreeThrowsAttempted,
                Rebounds = stats.Stats.Rebounds,
                Assists = stats.Stats.Assists,
                Steals = stats.Stats.Steals,
                Blocks = stats.Stats.Blocks,
                Turnovers = stats.Stats.Turnovers,
                Fouls = stats.Stats.Fouls
            };

            var embeddingText = $@"
            Baseball Stats
            League: {vector.LeagueName}
            Team: {vector.TeamName}
            Player: {vector.FullName}
            Season: {vector.SeasonYear}
            Game ID: {vector.GameId}

            Game Score
            Home Team: {vector.HomeTeamName} ({vector.HomeTeamScore})
            Away Team: {vector.AwayTeamName} ({vector.AwayTeamScore})

            Performance
            Start: {vector.Start}
            Minutes: {vector.Minutes}
            Points: {vector.Points}
            Field Goals: {vector.FieldGoalsMade}/{vector.FieldGoalsAttempted}
            Three Pointers: {vector.ThreePointersMade}/{vector.ThreePointersAttempted}
            Free Throws: {vector.FreeThrowsMade}/{vector.FreeThrowsAttempted}
            Rebounds: {vector.Rebounds}
            Assists: {vector.Assists}
            Steals: {vector.Steals}
            Blocks: {vector.Blocks}
            Turnovers: {vector.Turnovers}
            Fouls: {vector.Fouls}
            ";

            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;

            await _basketballStatsCollection.UpsertAsync(vector);

        }
    }

    // ------------------------------------------------------------
    // FOOTBALL STATS
    // ------------------------------------------------------------
    private async Task IngestFootballStatsAsync()
    {
        foreach (var stats in _cache.LeagueData.FootballStats)
        {
            var league = _cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == stats.LeagueId);
            var season = _cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == stats.SeasonId);
            var game = _cache.LeagueData.Games.FirstOrDefault(game => game.Id == stats.GameId);
            var team = _cache.LeagueData.Teams.FirstOrDefault(team => team.Id == stats.TeamId);
            var player = _cache.LeagueData.Players.FirstOrDefault(player => player.Id == stats.PlayerId);

            var vector = new FootballStats
            {
                Id = stats.Id,
                LeagueId = stats.LeagueId.ToString(),
                LeagueName = league?.Name ?? string.Empty,
                TeamId = stats.TeamId.ToString(),
                TeamName = team?.TeamName ?? string.Empty,
                PlayerId = stats.PlayerId.ToString(),
                FullName = $"{player?.FirstName} {player?.LastName}",
                SeasonId = stats.SeasonId.ToString(),
                SeasonYear = season?.Year ?? 0,
                GameId = stats.GameId.ToString(),
                AwayTeamId = game?.AwayTeam.Id.ToString(),
                AwayTeamName = game?.AwayTeam.TeamName ?? string.Empty,
                HomeTeamId = game?.HomeTeam.Id.ToString(),
                HomeTeamName = game?.HomeTeam.TeamName ?? string.Empty,
                AwayTeamScore = game?.GameDetail.AwayTeamScore ?? 0,
                HomeTeamScore = game?.GameDetail.HomeTeamScore ?? 0,
                PassingCompletions = stats.OffensiveStats.PassingCompletions,
                PassingAttempts = stats.OffensiveStats.PassingAttempts,
                PassingYards = stats.OffensiveStats.PassingYards,
                LongestPassingPlay = stats.OffensiveStats.LongestPassingPlay,
                PassingTouchdowns = stats.OffensiveStats.PassingTouchdowns,
                PassingInterceptions = stats.OffensiveStats.PassingInterceptions,
                Sacks = stats.OffensiveStats.Sacks,
                RushingAttempts = stats.OffensiveStats.RushingAttempts,
                RushingYards = stats.OffensiveStats.RushingYards,
                LongestRushingPlay = stats.OffensiveStats.LongestRushingPlay,
                RushingTouchdowns = stats.OffensiveStats.RushingTouchdowns,
                RushingFumbles = stats.OffensiveStats.RushingFumbles,
                RushingFumblesLost = stats.OffensiveStats.RushingFumblesLost,
                Receptions = stats.OffensiveStats.Receptions,
                Targets = stats.OffensiveStats.Targets,
                ReceivingYards = stats.OffensiveStats.ReceivingYards,
                ReceivingTouchdowns = stats.OffensiveStats.ReceivingTouchdowns,
                ReceivingFumbles = stats.OffensiveStats.ReceivingFumbles,
                ReceivingFumblesLost = stats.OffensiveStats.ReceivingFumblesLost,
                YardsAfterCatch = stats.OffensiveStats.YardsAfterCatch,
                Tackles = stats.DefensiveStats.Tackles,
                DefensiveSacks = stats.DefensiveStats.Sacks,
                TacklesForLoss = stats.DefensiveStats.TacklesForLoss,
                PassesDefended = stats.DefensiveStats.PassesDefended,
                DefensiveInterceptions = stats.DefensiveStats.DefensiveInterceptions,
                DefensiveInterceptionYards = stats.DefensiveStats.DefensiveInterceptionYards,
                LongestDefensiveInterceptionPlay = stats.DefensiveStats.LongestDefensiveInterceptionPlay,
                DefensiveTouchdowns = stats.DefensiveStats.DefensiveTouchdowns,
                ForcedFumbles = stats.DefensiveStats.ForcedFumbles,
                RecoveredFumbles = stats.DefensiveStats.RecoveredFumbles,
                FieldGoalsMade = stats.KickingStats.FieldGoalsMade,
                FieldGoalsAttempted = stats.KickingStats.FieldGoalsAttempted,
                ExtraPointsMade = stats.KickingStats.ExtraPointsMade,
                ExtraPointsAttempted = stats.KickingStats.ExtraPointsAttempted,
                LongestKick = stats.KickingStats.LongestKick,
                Points = stats.KickingStats.Points,
                Punts = stats.KickingStats.Punts,
                PuntingYards = stats.KickingStats.PuntingYards,
                LongestPunt = stats.KickingStats.LongestPunt
            };

            var embeddingText = $@"
            Football Stats
            League: {vector.LeagueName}
            Team: {vector.TeamName}
            Player: {vector.FullName}
            Season: {vector.SeasonYear}
            Game ID: {vector.GameId}

            Game Score
            Home Team: {vector.HomeTeamName} ({vector.HomeTeamScore})
            Away Team: {vector.AwayTeamName} ({vector.AwayTeamScore})

            Passing
            Completions: {vector.PassingCompletions}
            Attempts: {vector.PassingAttempts}
            Yards: {vector.PassingYards}
            Longest Play: {vector.LongestPassingPlay}
            Touchdowns: {vector.PassingTouchdowns}
            Interceptions: {vector.PassingInterceptions}
            Sacks: {vector.Sacks}

            Rushing
            Attempts: {vector.RushingAttempts}
            Yards: {vector.RushingYards}
            Longest Play: {vector.LongestRushingPlay}
            Touchdowns: {vector.RushingTouchdowns}
            Fumbles: {vector.RushingFumbles}
            Fumbles Lost: {vector.RushingFumblesLost}

            Receiving
            Receptions: {vector.Receptions}
            Targets: {vector.Targets}
            Yards: {vector.ReceivingYards}
            Touchdowns: {vector.ReceivingTouchdowns}
            Fumbles: {vector.ReceivingFumbles}
            Fumbles Lost: {vector.ReceivingFumblesLost}
            Yards After Catch: {vector.YardsAfterCatch}

            Defense
            Tackles: {vector.Tackles}
            Sacks: {vector.DefensiveSacks}
            Tackles For Loss: {vector.TacklesForLoss}
            Passes Defended: {vector.PassesDefended}
            Interceptions: {vector.DefensiveInterceptions}
            Interception Yards: {vector.DefensiveInterceptionYards}
            Longest INT Play: {vector.LongestDefensiveInterceptionPlay}
            Touchdowns: {vector.DefensiveTouchdowns}
            Forced Fumbles: {vector.ForcedFumbles}
            Recovered Fumbles: {vector.RecoveredFumbles}

            Kicking
            Field Goals: {vector.FieldGoalsMade}/{vector.FieldGoalsAttempted}
            Extra Points: {vector.ExtraPointsMade}/{vector.ExtraPointsAttempted}
            Longest Kick: {vector.LongestKick}
            Points: {vector.Points}

            Punting
            Punts: {vector.Punts}
            Yards: {vector.PuntingYards}
            Longest Punt: {vector.LongestPunt}
            ";

            var embedding = await _embedding.GenerateAsync(embeddingText);
            vector.Vector = embedding.Vector;

            await _footballStatsCollection.UpsertAsync(vector);

        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

