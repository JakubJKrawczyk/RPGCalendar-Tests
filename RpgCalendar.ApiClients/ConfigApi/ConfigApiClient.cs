using RestSharp;
using RpgCalendar.Utilities;

namespace RpgCalendar.ApiClients.ConfigApi;

public record keycloakData(string ClientId, string ClientSecret, string Realm);

public class ConfigApiClient
{
    private static RestClient? _client;
    private static RestClient Client => _client ??= new RestClient(EnvironmentData.ConfigApiUrl);

    public keycloakData GetKeycloakConfig()
    {
        throw new NotImplementedException();
    }
}