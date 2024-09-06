namespace AiBlazorApp.Config;

public class AppConfig : IAppConfig
{
    public string? AppName { get; set; }
    public string? Environment { get; set; } 
}
