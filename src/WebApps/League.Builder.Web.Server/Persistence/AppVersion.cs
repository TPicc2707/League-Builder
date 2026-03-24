using System.Reflection;

namespace League.Builder.Web.Server.Persistence;

public static class AppVersion
{
    public static string Full =>
        Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion
        ?? "Unknown";

    public static string Short =>
        Full.Contains('+')
            ? $"{Full.Split('+')[0]} ({Full.Split('+')[1][..7]})"
            : Full;
}
