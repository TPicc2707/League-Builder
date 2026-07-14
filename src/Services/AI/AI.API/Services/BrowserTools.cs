using System.Text.Json;

namespace AI.API.Services;

public class BrowserTools
{
    private readonly object _tabs;

    public BrowserTools(IConfiguration config)
    {
        // You can inject your edge_all_open_tabs here
        _tabs = new[]
        {
            new
            {
                pageTitle = "Remove Background from Image - remove.bg",
                pageUrl = "https://www.remove.bg/upload",
                tabId = 141319134,
                isCurrent = true
            }
        };
    }

    public object GetBrowserTabs() => _tabs;
}
