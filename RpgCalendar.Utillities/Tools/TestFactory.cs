using RpgCalendar_InternalApi.ExternalClients;
using RpgCalendar_InternalApi.internalApi;
using RpgCalendar_InternalApi.models;

namespace RpgCalendar.Utillities;

public class TestFactory
{
    private KeyCloakClient _kcClient;
    private InternalApi _internalApiClient;
    public TestFactory()
    {
        _kcClient = new(Config.KeyCloak.ClientId, Config.KeyCloak.ClientSecret);
        _internalApiClient = new();
    }

    public void PreapareUser(string? name = null)
    {
        name ??= Rnd.String();

        _kcClient.CreateUser(name);
        _internalApiClient.RegisterUser(name, );
        
        
    }
}