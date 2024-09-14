using RpgCalendar.ApiClients.ExternalClients.Keycloak;
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
    private kcUserModel kcu;
    
    public Guid UserId => u.id;
    public string DisplayName => u.displayName;
    public string PrivateCode => u.privateCode;

    public static User Prepare(string displayName) => new(new user()
        {
            displayName = displayName,
        });

    public User Create()
    {
        var keycloakClient = new KeyCloakClient();
        (userCredentials kredki, kcUserModel user) response = keycloakClient.AddUser(uc.username, uc.password);

        uc = response.kredki;
        kcu = response.user;
        return this;
    }

    public Success Delete()
    {
        throw new NotImplementedException();
    }
    public User Refresh()
    {
        if(kcu.id is null) throw new NullReferenceException("Keycloak client id is null. Refresh is impossible.");
        
        var keycloakClient = new KeyCloakClient();
        kcu = keycloakClient.GetUserById(kcu.id);

        return this;
    }
    
}