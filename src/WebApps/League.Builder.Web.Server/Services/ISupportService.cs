namespace League.Builder.Web.Server.Services;

public interface ISupportService
{
    Task<string> SupportChat(string query);
}
