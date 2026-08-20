namespace League.Builder.Web.Server.Models.Ai;

public record AiQueryRequest(string Question);
public record AiGameRecapRequest(string Question);
public record AiQueryResponse(string Response);
public record AiGameRecapResponse(string Response);
