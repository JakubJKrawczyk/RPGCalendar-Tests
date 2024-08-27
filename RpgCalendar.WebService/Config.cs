using RpgCalendar.ApiClients.ConfigApi;

namespace RpgCalendar_WebService;

public record KeycloakData(string ClientId, string ClientSecret, string Realm);

public static class Config
{
    public static KeycloakData KeyCloak { get; }
}