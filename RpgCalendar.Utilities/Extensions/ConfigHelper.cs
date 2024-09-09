using RestSharp;

namespace RpgCalendar.Utilities.Extensions;

public class ConfigHelper
{
    private static RestClient _client = new RestClient("https://dev.rpg-calendar.jakubkrawczyk.com");
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
            var response = _client.Execute<Dictionary<string, string>>(request).Data;

            if(response is null) throw new NullReferenceException("Config is null");
            return new configRecord(
                response["KEYCLOAK_CLIENTID"],
                response["KEYCLOAK_CLIENTSECRET"],
                response["KEYCLOAK_REALM"],
                response["KEYCLOAK_HOST"],
                response["TESTS_CONFIG_API"],
                response["TESTS_ENVIRONMENT"]
                );
        }
    #endregion

    public static configRecord Config => getConfig();


}