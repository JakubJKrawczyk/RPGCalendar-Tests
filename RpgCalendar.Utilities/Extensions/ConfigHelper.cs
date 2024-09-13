using RestSharp;

namespace RpgCalendar.Utilities.Extensions;

public class ConfigHelper
{
    private static RestClient _client = new RestClient("https://config.rpg-calendar.jakubkrawczyk.com/");
    public record configRecord(
        string KEYCLOAK_CLIENTID,
        string KEYCLOAK_CLIENTSECRET,
        string KEYCLOAK_REALM,
        string KEYCLOAK_HOST,
        string TESTS_CONFIG_API,
        string TESTS_ENVIRONMENT
    );
    
    #region prywatne metody
        private static configRecord getConfig()
        {
            RestRequest request = new RestRequest("/config");
            var response = _client.Execute<Dictionary<string, string>>(request);

            if(response.Data is null) throw new NullReferenceException("Config is null");
            return new configRecord(
                response.Data["KEYCLOAK_CLIENTID"],
                response.Data["KEYCLOAK_CLIENTSECRET"],
                response.Data["KEYCLOAK_REALM"],
                response.Data["KEYCLOAK_HOST"],
                response.Data["TESTS_CONFIG_API"],
                response.Data["TESTS_ENVIRONMENT"]
                );
        }
    #endregion

    public static configRecord Config => getConfig();


}