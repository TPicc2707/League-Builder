﻿global using BuildingBlocks.Exceptions.Handler;
global using BuildingBlocks.Pagination;
global using Carter;
global using HealthChecks.UI.Client;
global using Mapster;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Stats.API;
global using Stats.Application;
global using Stats.Application.Dtos;
global using Stats.Application.Stats.BaseballStats.Commands.CreateBaseballStats;
global using Stats.Application.Stats.BaseballStats.Commands.DeleteBaseballStats;
global using Stats.Application.Stats.BaseballStats.Commands.UpdateBaseballStats;
global using Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatById;
global using Stats.Application.Stats.BaseballStats.Queries.GetBaseballStats;
global using Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByLeague;
global using Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByPlayer;
global using Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByTeam;
global using Stats.Application.Stats.BaseballStats.Queries.GetLeagueBaseballStatsBySeason;
global using Stats.Application.Stats.BaseballStats.Queries.GetPlayerBaseballStatsByGame;
global using Stats.Application.Stats.BaseballStats.Queries.GetPlayerBaseballStatsBySeason;
global using Stats.Application.Stats.BaseballStats.Queries.GetTeamBaseballStatsByGame;
global using Stats.Application.Stats.BaseballStats.Queries.GetTeamBaseballStatsBySeason;
global using Stats.Application.Stats.BasketballStats.Commands.CreateBasketballStats;
global using Stats.Application.Stats.BasketballStats.Commands.DeleteBasketballStats;
global using Stats.Application.Stats.BasketballStats.Commands.UpdateBasketballStats;
global using Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatById;
global using Stats.Application.Stats.BasketballStats.Queries.GetBasketballStats;
global using Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByLeague;
global using Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByPlayer;
global using Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByTeam;
global using Stats.Application.Stats.BasketballStats.Queries.GetLeagueBasketballStatsBySeason;
global using Stats.Application.Stats.BasketballStats.Queries.GetPlayerBasketballStatsByGame;
global using Stats.Application.Stats.BasketballStats.Queries.GetPlayerBasketballStatsBySeason;
global using Stats.Application.Stats.BasketballStats.Queries.GetTeamBasketballStatsByGame;
global using Stats.Application.Stats.BasketballStats.Queries.GetTeamBasketballStatsBySeason;
global using Stats.Application.Stats.FootballStats.Commands.CreateFootballStats;
global using Stats.Application.Stats.FootballStats.Commands.DeleteFootballStats;
global using Stats.Application.Stats.FootballStats.Commands.UpdateFootballStats;
global using Stats.Application.Stats.FootballStats.Queries.GetFootballStats;
global using Stats.Application.Stats.FootballStats.Queries.GetFootballStatsById;
global using Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByLeague;
global using Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByPlayer;
global using Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByTeam;
global using Stats.Application.Stats.FootballStats.Queries.GetLeagueFootballStatsBySeason;
global using Stats.Application.Stats.FootballStats.Queries.GetPlayerFootballStatsByGame;
global using Stats.Application.Stats.FootballStats.Queries.GetPlayerFootballStatsBySeason;
global using Stats.Application.Stats.FootballStats.Queries.GetTeamFootballStatsByGame;
global using Stats.Application.Stats.FootballStats.Queries.GetTeamFootballStatsBySeason;
global using Stats.Infrastructure;
global using Stats.Infrastructure.Data.Extensions;

