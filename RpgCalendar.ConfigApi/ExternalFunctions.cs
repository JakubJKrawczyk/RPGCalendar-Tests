using System.Dynamic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RpgCalendar.ConfigApi;

public class ExternalFunctions
{
    private static Regex regex = new("^[a-zA-Z]+=.+$");
    public static Dictionary<string, object> GetEnvs()
    {
        if (File.Exists(Consts.CONFIG_API_PATH))
        {
            var text = File.ReadAllText(Consts.CONFIG_API_PATH);

            return JsonSerializer.Deserialize<Dictionary<string, object>>(text);
            
            
        }

        return null;

    }
}