using RpgCalendar_InternalApi.ExternalClients;
using RpgCalendar.ApiClients.InternalApi;
using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Tools;
using RpgCalendar.WebService;

namespace RpgCalendar.Tests;

public class TestFactory
{
    private readonly KeyCloakClient _kcClient;
    private readonly InternalApiClient _internalApiClient;
    
    public TestFactory()
    {
        _kcClient = new(Config.KeyCloak.ClientId, Config.KeyCloak.ClientSecret, Config.KeyCloak.Realm);
        _internalApiClient = new();
    }

    public void PrepareUser(string? name = null)
    {
        name ??= Rnd.String();

        _kcClient.CreateUser(name);
        _internalApiClient.RegisterUser(name, );
        
        
    }
}