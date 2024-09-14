using RestSharp;
using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Extensions;

namespace RpgCalendar.ApiClients.ConfigApi;

public record keycloakData(string ClientId, string ClientSecret, string Realm, string Host);

public class ConfigApiClient
{
    private static RestClient? _client;
    private static RestClient Client => _client ??= new RestClient(EnvironmentData.ConfigApiUrl, options =>
    {
        options.RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true;
    });

    public keycloakData GetKeycloakConfig()
    {
        return new keycloakData(
            ConfigHelper.Config.KeycloakClientId,
            ConfigHelper.Config.KeycloakClientSecret,
            ConfigHelper.Config.KeycloakRealm,
            ConfigHelper.Config.KeycloakHost
            );
    }
}