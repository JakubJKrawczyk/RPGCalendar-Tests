using RestSharp;

namespace RpgCalendar.Utilities.Extensions;

public class ConfigHelper
{
    private static RestClient _client = new RestClient("https://config.rpg-calendar.jakubkrawczyk.com/", options =>
    {
        options.RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true;
    });
    public record configRecord(
        string KeycloakClientId,
        string KeycloakClientSecret,
        string KeycloakRealm,
        string KeycloakHost
    );
    
    #region prywatne metody
        private static Dictionary<string, string> getConfig()
        {
            RestRequest request = new RestRequest($"/{EnvironmentData.TestsEnv}");
            var response = _client.Execute<Dictionary<string, string>>(request);
            return response.Data ?? throw new NullReferenceException();
        }
    #endregion

    public static Dictionary<string, string> Config => getConfig();


}