using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace League.Builder.Web.Server.Models.Health;

public class HealthReport
{
    public IReadOnlyDictionary<string, HealthReportEntry> Entries { get; set; }
    public HealthStatus Status { get; set; }
    public TimeSpan TotalDuration { get; set; }
}

public class HealthReportEntry
{
    public HealthStatus Status { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public IReadOnlyDictionary<string, object> Data { get; set; }
    public IEnumerable<string> Tags { get; set; }
}
