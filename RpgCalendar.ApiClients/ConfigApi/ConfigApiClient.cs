using RestSharp;
using RpgCalendar.ConfigApi;
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
            ConfigHelper.Config[ConfigConsts.CONFIG_ENV_NAME_CLIENTID],
            ConfigHelper.Config[ConfigConsts.CONFIG_ENV_NAME_CLIENTSECRET],
            ConfigHelper.Config[ConfigConsts.CONFIG_ENV_NAME_REALM],
            ConfigHelper.Config[ConfigConsts.CONFIG_ENV_NAME_HOST]
            );
    }
}