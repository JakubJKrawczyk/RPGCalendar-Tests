using NUnit.Framework.Constraints;
using RestSharp;
using RpgCalendar.ApiClients.ConfigApi;
using RpgCalendar.Utilities;

namespace RpgCalendar.ApiClients.ExternalClients;

public class KeyCloakClient
{
    private readonly RestClient _client;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _realm;

    private string ClientToken => GetClientToken();

    public KeyCloakClient()
    {
        var configClient = new ConfigApiClient().GetKeycloakConfig();
        _clientId = configClient.ClientId;
        _clientSecret = configClient.ClientSecret;
        _realm = configClient.Realm;
        _client = new RestClient($"{configClient.Host}");
        _client.AddDefaultParameter("Content-Type", ContentType.FormUrlEncoded);
    }

    private string GetClientToken()
    {
        RestRequest request = new RestRequest($"realms/{_realm}/protocol/openid-connect/token", Method.Post);
        
        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);

        var response = _client.Execute<ClientToken>(request);
        if(response.Data is null) throw new KeyCloakException(response);
        return response.Data.access_token;
    }
    
    public void GetUserToken(string username, string password = Consts.DefaultPassword)
    {
        RestRequest request = new RestRequest($"realms/{_realm}/protocol/openid-connect/token", Method.Post);
        
        request.AddParameter("grant_type", "password");
        request.AddParameter("username", username);
        request.AddParameter("password", password);
    }

    // curl -v http://localhost:8080/auth/admin/realms/apiv2/users -H "Content-Type: application/json" -H "Authorization: bearer $TOKEN"   --data '{"firstName":"xyz","lastName":"xyz", "username":"xyz123","email":"demo2@gmail.com", "enabled":"true","credentials":[{"type":"password","value":"test123","temporary":false}]}'
    public void AddUser(string username, string password = Consts.DefaultPassword)
    {
        RestRequest request = new RestRequest($"admin/realms/{_realm}/users", Method.Post);
        request.AddHeader("Authorization", $"Bearer {ClientToken}");
        request.AddBody(new {username});
    }

    public void GetUserByName(string username)
    {
        RestRequest request = new RestRequest($"users", Method.Get);
        request.AddHeader("Authorization", $"Bearer {ClientToken}");
        request.AddParameter("username", username);
    }
}



public class KeyCloakException : Exception
{
    public KeyCloakException(RestResponse response) : base(response.ErrorMessage)
    {
        
    }
}