using RpgCalendar.ApiClients.ConfigApi;

namespace RpgCalendar.WebService;

public class KeycloakData(keycloakData keycloakData)
{
    private readonly keycloakData kd = keycloakData;
    public string ClientId => kd.ClientId;
    public string ClientSecret => kd.ClientSecret;
    public string Realm => kd.Realm;
    public string Host => kd.Host;
}

public static class Config
{
    public static KeycloakData KeyCloak => new KeycloakData(new ConfigApiClient().GetKeycloakConfig());
}