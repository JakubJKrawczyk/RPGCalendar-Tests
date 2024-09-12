using RestSharp;
using RpgCalendar.Utilities.Extensions;

namespace RpgCalendar.Utilities;

public static class EnvironmentData
{
    private const string ConfigApiEnv = "TESTS_CONFIG_API";
    public static string ConfigApiUrl => Environment.GetEnvironmentVariable(ConfigApiEnv) ?? "https://config.rpg-calednar.jakubkrawczyk.com";
    
    private const string TestsEnvEnv = "TESTS_ENVIRONMENT";
    public static string TestsEnv => Environment.GetEnvironmentVariable(TestsEnvEnv) ?? "dev";
}