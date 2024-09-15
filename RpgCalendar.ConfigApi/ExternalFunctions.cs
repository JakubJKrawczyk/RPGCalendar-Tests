using System.Dynamic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RpgCalendar.ConfigApi;

public static class ExternalFunctions
{
    public static Dictionary<string, string> GetEnvs(string environment)
    {
        if (File.Exists(ConfigConsts.CONFIG_API_PATH))
        {
            var text = File.ReadAllText(ConfigConsts.CONFIG_API_PATH);
            var deserialized = JsonSerializer.Deserialize<Models.EnvContainers>(text);
            if (deserialized is not null)
            {
                try
                {
                    var envs = deserialized.Containers.First(x => x.ContainsValue(environment));
                    return envs;
                }
                catch (Exception ex)
                {
                    throw new ConfigException(environment, ex.Message);
                }
            }
        }

        return null!;
    }

    public static List<string> GetEnvsNames(string environment)
    {
        if (File.Exists(ConfigConsts.CONFIG_API_PATH))
        {
            var text = File.ReadAllText(ConfigConsts.CONFIG_API_PATH);
            var deserialized = JsonSerializer.Deserialize<Models.EnvContainers>(text);
            if (deserialized is not null)
            {
                try
                {
                    return deserialized.Containers.First(x => x.ContainsValue(environment)).Keys.ToList();
                }
                catch (Exception ex)
                {
                    throw new ConfigException(environment, ex.Message);
                }
            }
        }

        return null!;
    }
}



public class ConfigException : Exception
{
    public ConfigException(string environment,string message) : base($"chuj ci w dupe. Config pozdrawia ({environment}): {message}")
    {
        
    }
}