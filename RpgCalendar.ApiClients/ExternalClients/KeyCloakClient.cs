using System.Data;
using RestSharp;

namespace RpgCalendar_InternalApi.ExternalClients;

public class KeyCloakClient
{
    private readonly RestClient _client;
    private string _realm;
    private string _clientId;
    private string _clientSecret;

    private string _clientToken => GetClientToken();
    
    public KeyCloakClient()
    {
        _realm = "rpgcalendar";
        _client = new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri($"https://auth.dev.rpg-calenauth.dev.rpg-calendar.jakubkrawczyk.com/realms/{_realm}/"),
        });
            
    }

    private string GetClientToken()
    {
        RestRequest request = new RestRequest($"protocol/openid-connect/token", Method.Post);
        
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);

        var response = _client.Execute<ClientToken>(request);
        if(response.Data is null) throw new KeyCloakException(response);
        return response.Data.access_token;
    }

    private void AddUser(string username)
    {
        RestRequest request = new RestRequest($"users/", Method.Post);
        request.AddHeader("Authorization", $"Bearer {GetClientToken()}");
        request.AddBody(new {username});
    }

    private void GetUserByName(string username)
    {
        RestRequest request = new RestRequest($"users", Method.Get);
        request.AddHeader("Authorization", $"Bearer {GetClientToken()}");
        request.AddParameter("username", username);   
    }

    public KeyCloakClient(string keyCloakClientId, string keyCloakClientSecret, string keyCloakRealm)
    {
        throw new NotImplementedException();
    }
}



public class KeyCloakException : Exception
{
    public KeyCloakException(RestResponse response) : base(response.ErrorMessage)
    {
        
    }
}