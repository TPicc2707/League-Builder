namespace League.Builder.Web.Services;

public interface ISeasonService
{
    [Get("/season-service/seasons?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetSeasonsResponse> GetSeasons(int? pageNumber = 1, int? pageSize = 10);
    [Get("/season-service/seasons/{id}")]
    Task<GetSeasonByIdResponse> GetSeason(Guid id);
    [Get("/season-service/seasons/year/{year}")]
    Task<GetSeasonByYearResponse> GetSeasonByYear(int year);
    [Post("/season-service/seasons")]
    Task<CreateSeasonResponse> CreateSeason(CreateSeasonRequest request);
    [Put("/season-service/seasons")]
    Task<UpdateSeasonResponse> UpdateSeason(UpdateSeasonRequest request);
    [Delete("/season-service/seasons/{id}")]
    Task<DeleteSeasonResponse> DeleteSeason(Guid id);
}
