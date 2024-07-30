namespace RSS_Feeder.Settings;

public static class SettingsOptions
{
    public static string? RssUrl { get; set; }
    public static string? ProxyAddress { get; set; }
    public static string? ProxyLogin { get; set; }
    public static string? ProxyPassword { get; set; }
    public static bool UseProxy { get; set; }
    public static int RefreshRate { get; set; }
    
    
}