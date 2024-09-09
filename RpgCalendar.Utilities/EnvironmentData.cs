using RestSharp;
using RpgCalendar.Utilities.Extensions;

namespace RpgCalendar.Utilities;

public static class EnvironmentData
{
    public static string ConfigApiUrl => ConfigHelper.Config.TESTS_CONFIG_API ?? "https://testapi.rpg-calednar.jakubkrawczyk.com";
    public static string TestsEnv => ConfigHelper.Config.TESTS_ENVIRONMENT ?? "dev";
}