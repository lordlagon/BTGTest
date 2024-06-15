namespace Core;

public static class Constants
{
    public static string Database => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db");
}
