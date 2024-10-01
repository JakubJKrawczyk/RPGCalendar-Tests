using RpgCalendar.ApiClients.ExternalClients.Keycloak;
using RpgCalendar.ApiClients.InternalApi;
using RpgCalendar.ApiClients.InternalApi.Models;
using RpgCalendar.Utilities;

namespace RpgCalendar.WebService;

public class User()
{
    private user u;

    private userCredentials uc;
    private kcUserModel? kcu;

    private User(user user, string? username = null, string password = Consts.DefaultPassword) : this()
    {
        u = user;
        uc = new userCredentials(username ?? user.displayName, password);
    }

    public Guid? UserId => u.id;
    public string DisplayName => u.displayName;
    public string PrivateCode => u.privateCode;

    public string Password => uc.password;

    public static User Prepare(string displayName) => new(new user()
        {
            displayName = displayName,
        });

    public User WithToken(string token)
    {
        uc = uc with { token = token };

        return this;
    }

    public User WithPassword(string password)
    {
        uc = uc with { password = password };
        
        return this;
    }

    public User WithName(string username)
    {
        u.displayName = username;
        
        return this;
    }

    public User Create()
    {
        CreateKeyCloak();
        CreateInternal();
        
        return this;
    }

    public User CreateKeyCloak()
    {
        //Strefa KeyCloak
        var kClient = KeyCloakClient.Instance;
        (userCredentials kredki, kcUserModel user) response = kClient.AddUser(DisplayName,  Password);
        uc = response.kredki;
        kcu = response.user;

        return this;
    }
    public User CreateInternal()
    {
        if(uc.token is null || uc.username is null) throw new NullReferenceException();
        u = InternalApiClient.Users.addUser(uc.username, uc.token);

        return this;
    }
    
    public void DeleteKeycloak()
    {
        var keycloakClient = new KeyCloakClient();
        if (kcu?.id is null) throw new NullReferenceException("Keycloak client is null");
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

        u.displayName = me.displayName;
        u.privateCode = me.privateCode;
        u.id = me.id;
        
        return this;
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