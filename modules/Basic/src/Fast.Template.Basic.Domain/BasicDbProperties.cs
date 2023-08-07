namespace Fast.Template.Basic;

public static class BasicDbProperties
{
    public static string DbTablePrefix { get; set; } = "basic_";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Basic";
}
