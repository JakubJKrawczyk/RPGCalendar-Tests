using RestSharp;
using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Extensions;

namespace RpgCalendar.ApiClients.ConfigApi;

public record keycloakData(string ClientId, string ClientSecret, string Realm, string Host);

public class ConfigApiClient
{
    private static RestClient? _client;
    private static RestClient Client => _client ??= new RestClient(EnvironmentData.ConfigApiUrl);

    public keycloakData GetKeycloakConfig()
    {
        return new keycloakData(
            ConfigHelper.Config.KEYCLOAK_CLIENTID,
            ConfigHelper.Config.KEYCLOAK_CLIENTSECRET,
            ConfigHelper.Config.KEYCLOAK_REALM,
            ConfigHelper.Config.KEYCLOAK_HOST
            );
    }
}