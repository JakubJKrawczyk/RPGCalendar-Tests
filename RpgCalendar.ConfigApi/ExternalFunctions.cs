using System.Dynamic;
using System.Text.RegularExpressions;

namespace RpgCalendar.ConfigApi;

public class ExternalFunctions
{
    private static Regex regex = new("^[a-zA-Z]+=.+$");
    public static ExpandoObject GetEnvs()
    {
        if (File.Exists(Consts.CONFIG_API_PATH))
        {
            var text = File.ReadAllLines(Consts.CONFIG_API_PATH);

            dynamic response = new ExpandoObject();

            IDictionary<string, object> responseDic = response;
            
            foreach (string line in text)
            {
                if(!regex.Match(line).Success) continue;
                var keyvalue = line.Split('=');
                responseDic.Add(keyvalue[0], keyvalue[1]);
                
            }
            return response;
        }

        return null;

    }
}