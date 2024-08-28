using RpgCalendar_InternalApi.ExternalClients;
using RpgCalendar.ApiClients.ExternalClients;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.WebService;

public class User
{
    private user u;
    private string username;
    
    public Guid UserId => u.id;
    public string DisplayName => u.displayName;
    public string PrivateCode => u.privateCode;

    public static User Prepare(string displayName)
    {
        return new User()
        {
            u = new user()
            {
                displayName = displayName,
            }
        };
    }
    
    public User Create()
    {
        var keycloakClient = new KeyCloakClient();
        keycloakClient.AddUser(username, "password");
        return this;
    }
}