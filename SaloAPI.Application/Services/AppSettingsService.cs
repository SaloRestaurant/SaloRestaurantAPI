namespace SaloAPI.Application.Services;

public static class AppSettingsService
{
    private const string AppSettingsPath = "../../../../SaloAPI.Presentation/appsettings.json";

    public static string GetAppSettingsPath()
    {
        var path = Path.Combine(AppContext.BaseDirectory, AppSettingsPath);
        return path;
    }
}