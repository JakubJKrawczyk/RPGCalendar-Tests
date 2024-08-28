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
        uc = keycloakClient.AddUser(uc.username, uc.password);
        return this;
    }
}