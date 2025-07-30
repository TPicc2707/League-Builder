namespace League.Builder.Web.Server.Services;

public interface IAWSService
{
    Task<bool> UploadImages(string keyPath, IBrowserFile file);
    Task<bool> CopyObjectToNewFolder(string sourceKeyPath, string destinationKeyPath);
    Task<string> GetImage(string keyPath);
    Task DeleteObject(string keyPath);
    Task DeleteObjects(string keyPath);
}
