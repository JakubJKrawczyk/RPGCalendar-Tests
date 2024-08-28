using RestSharp;
using RpgCalendar.ApiClients.ConfigApi;
using RpgCalendar.ApiClients.InternalApi.Models;
using RpgCalendar.Utilities;

namespace RpgCalendar.ApiClients.ExternalClients.Keycloak;

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
        _client = new RestClient($"{configClient.Host}", 
            options => options.RemoteCertificateValidationCallback = (_, _, _, _) => true);
        _client.AddDefaultParameter("Content-Type", ContentType.FormUrlEncoded);
    }
    
    private T Execute<T>(RestRequest request)
    {
        var response = _client.Execute<T>(request);

        if (!response.IsSuccessful || response.Data is null) throw new KeyCloakException(response);
        
        return response.Data;
    }
    
    private bool Execute(RestRequest request)
    {
        var response = _client.Execute(request);

        if (!response.IsSuccessful) throw new KeyCloakException(response);
        
        return true;
    }

    private string GetClientToken()
    {
        RestRequest request = new RestRequest($"realms/{_realm}/protocol/openid-connect/token", Method.Post);
        
        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);

        return Execute<clientToken>(request).access_token;
    }
    
    public userCredentials GetUserToken(string username, string password = Consts.DefaultPassword)
    {
        RestRequest request = new RestRequest($"realms/{_realm}/protocol/openid-connect/token", Method.Post);
        
        request.AddParameter("grant_type", "password");
        request.AddParameter("username", username);
        request.AddParameter("password", password);

        var resp = Execute<userToken>(request);

        return new userCredentials(username, password, resp.access_token);
    }
    
    public userCredentials AddUser(string username, string password = Consts.DefaultPassword)
    {
        RestRequest request = new RestRequest($"admin/realms/{_realm}/users", Method.Post);
        request.AddHeader("Authorization", $"Bearer {ClientToken}");
        request.AddOrUpdateHeader("Content-Type", ContentType.Json);
        var body = new kcUserModel(username, username, username, $"{username}@{Consts.EmailDomain}", true,
            [new kcUserCredentials("password", password, false)]);
        request.AddJsonBody(body);

        Execute(request);
        
        return GetUserToken(username, password);
    }
}

public class KeyCloakException : Exception
{
    public KeyCloakException(RestResponse response) : base(response.ErrorMessage)
    {
        
    }
}

// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
public record clientToken(string access_token, int expires_in, int refresh_expires_in, string token_type,
    int not_before_policy, string scope);

public record userToken(string access_token, int expires_in, int refresh_expires_in, string refresh_token,
    string token_type, int not_before_policy, string session_state, string scope);

public record kcUserModel(string firstName, string lastName, string username, string email,
    bool enabled, kcUserCredentials[] credentials);

public record kcUserCredentials(string type, string value, bool temporary);

