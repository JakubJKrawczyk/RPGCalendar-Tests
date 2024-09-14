using System.Dynamic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RpgCalendar.ConfigApi;

public class ExternalFunctions
{
    private static Regex regex = new("^[a-zA-Z]+=.+$");
    public static Models.EnvContainers GetEnvs(string environment)
    {
        if (File.Exists(Consts.CONFIG_API_PATH))
        {
            var text = File.ReadAllText(Consts.CONFIG_API_PATH);
            var deserialized = JsonSerializer.Deserialize<Models.EnvContainers>(text);
            if(deserialized is not null) return deserialized;
            throw new ConfigException(environment, "Config envs are null.");
            
        }

        return null!;
    }
}



public class ConfigException : Exception
{
    public ConfigException(string environment,string message) : base($"ConfigAPI ({environment}): {message}")
    {
        
    }
}