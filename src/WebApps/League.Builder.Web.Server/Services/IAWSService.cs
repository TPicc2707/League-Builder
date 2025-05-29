namespace League.Builder.Web.Server.Services;

public interface IAWSService
{
    Task<bool> UploadImages(string keyPath, IBrowserFile file);
    Task<string> GetImage(string keyPath);

}
