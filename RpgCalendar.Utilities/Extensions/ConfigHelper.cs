using RestSharp;

namespace RpgCalendar.Utilities.Extensions;

public class ConfigHelper
{
    private static RestClient _client = new RestClient("https://config.rpg-calendar.jakubkrawczyk.com/");
    public record configRecord(
        string KeycloakClientId,
        string KeycloakClientSecret,
        string KeycloakRealm,
        string KeycloakHost
    );
    
    #region prywatne metody
        private static configRecord getConfig()
        {
            RestRequest request = new RestRequest($"/config/{EnvironmentData.TestsEnv}");
            var response = _client.Execute<configRecord>(request);
            return response.Data ?? throw new NullReferenceException();
        }
    #endregion

    public static configRecord Config => getConfig();


}