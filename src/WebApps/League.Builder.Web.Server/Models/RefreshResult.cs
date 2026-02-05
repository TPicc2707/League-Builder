namespace League.Builder.Web.Server.Models;

public class RefreshResult
{
    public bool Refreshed { get; set; }
    public bool Active { get; set; } = true;
    public bool Anonymous { get; set; } = false;
}
