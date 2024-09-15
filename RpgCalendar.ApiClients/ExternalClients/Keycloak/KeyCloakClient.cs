using RestSharp;
using RpgCalendar.ApiClients.ConfigApi;
using RpgCalendar.ApiClients.InternalApi.Models;
using RpgCalendar.Utilities;
using RpgCalendar.Utilities.Extensions;
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

    #region tokens
    
        private string GetClientToken()
        {
            RestRequest request = new RestRequest($"realms/{_realm}/protocol/openid-connect/token", Method.Post);
            request.AddHeader("Content-Type", ContentType.FormUrlEncoded);

            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", _clientId);
            request.AddParameter("client_secret", _clientSecret);

            return Execute<clientToken>(request).access_token;
        }
        
        public userCredentials GetUserToken(string username, string password = Consts.DefaultPassword)
        {
            RestRequest request = new RestRequest($"realms/{_realm}/protocol/openid-connect/token", Method.Post);
            request.AddHeader("Content-Type", ContentType.FormUrlEncoded);
            
            request.AddParameter("grant_type", "password");
            request.AddParameter("client_id", _clientId);
            request.AddParameter("client_secret", _clientSecret);
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            var resp = Execute<userToken>(request);

            return new userCredentials(username, password, resp.access_token);
        }
        
    #endregion

    #region Users
        
        public (userCredentials, kcUserModel) AddUser(string username, string password = Consts.DefaultPassword)
        {
            RestRequest request = new RestRequest($"/admin/realms/{_realm}/users/", Method.Post);
            var email = $"{username}@{Consts.EmailDomain}";
            request.AddHeader("Authorization", $"Bearer {ClientToken}");
            request.AddOrUpdateHeader("Content-Type", ContentType.Json);
            var body = new kcUserModel(username, username, username, email , true,
                [new kcUserCredentials("password", password, false)]);
            request.AddJson(body);

            Execute(request);
            
            return (GetUserToken(username, password), GetUser(username, username, username, email));
        }
        
        public Success DeleteUser(string userid)
        {
            RestRequest request = new RestRequest($"/admin/realms/{_realm}/users/{userid}", Method.Delete);

            return Execute<Success>(request);
        }
        
        public kcUserModel GetUser(string username, string firstname, string lastname, string email)
        {
            RestRequest request = new RestRequest($"/admin/realms/{_realm}/users", Method.Get);
            request.AddHeader("Content-Type", ContentType.FormUrlEncoded);
            request.AddHeader("Authorization", $"Bearer {ClientToken}");
            
            request.AddParameter("firstName", firstname);
            request.AddParameter("lastName", lastname);
            request.AddParameter("username", username);
            request.AddParameter("email", email);
            
            return Execute<kcUserModel[]>(request).First();
        }
        
        public kcUserModel GetUserById(string userId)
        {
            RestRequest request = new RestRequest($"/admin/realms/{_realm}/users/{userId}", Method.Get);

            return Execute<kcUserModel>(request);
        }
        
    #endregion
    
}

public class KeyCloakException : Exception
{
    private readonly RestResponse _response;
    public KeyCloakException(RestResponse response) : base(response.FromErrorMessage())
    {
        _response = response;
    }
}



