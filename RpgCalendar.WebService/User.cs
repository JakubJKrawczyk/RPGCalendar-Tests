using RpgCalendar.ApiClients.ExternalClients.Keycloak;
using RpgCalendar.ApiClients.InternalApi;
using RpgCalendar.ApiClients.InternalApi.Models;
using RpgCalendar.Utilities;

namespace RpgCalendar.WebService;

public class User()
{
    public User(user user, string? username = null, string password = Consts.DefaultPassword) : this()
    {
        u = user;
        uc = new (username ?? user.displayName, password);
    }
    
    private user u;
    private userCredentials uc;
    private kcUserModel? kcu;
    
    public Guid UserId => u.id;
    public string DisplayName => u.displayName;
    public string PrivateCode => u.privateCode;

    
    public static User Prepare(string displayName) => new(new user()
        {
            displayName = displayName,
        });

    public User WithToken(string token)
    {
        uc = uc with { token = token };

        return this;
    }

    public User WithName(string name)
    {
        u.displayName = name;

        return this;
    }
    public User Create()
    {
        //Strefa KeyCloak
        var kClient = KeyCloakClient.Instance;
        (userCredentials kredki, kcUserModel user) response = kClient.AddUser(uc.username,  uc.password);
        uc = response.kredki;
        kcu = response.user;
        
        //strefa internal API
        InternalApiClient.Users.addUser(uc.username, uc.token);
        
        return this;
    }

    public void Delete()
    {
        var keycloakClient = new KeyCloakClient();
        if (kcu is null) throw new NullReferenceException("Keycloak client is null");
        keycloakClient.DeleteUser(kcu.id);
    }

    public User GetMe()
    {
        user me;
        try
        {
            me = InternalApiClient.Users.getMe(uc.token);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return new User(me);
    }
    public User Refresh()
    {
        if(kcu.id is null) throw new NullReferenceException("Keycloak client id is null. Refresh is impossible.");
        
        var keycloakClient = new KeyCloakClient();
        kcu = keycloakClient.GetUserById(kcu.id);
        u = InternalApiClient.Users.getMe(uc.token);
        return this;
    }
    
}