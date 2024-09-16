using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public class InternalApiClient
{
    public static InternalApiClient Instance { get; } = new InternalApiClient();


    public static partial class Users
    {
        private static RestClient _client => new RestClient("https://dev.rpg-calendar.jakubkrawczyk.com", options =>
        {
            options.RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true;
        });
        
        private static T Execute<T>(RestRequest request)
        {
            var response = _client.Execute<T>(request);

            if (!response.IsSuccessful || response.Data is null) throw new InternalAPIException(response);
        
            return response.Data;
        }
    
        private static bool Execute(RestRequest request)
        {
            var response = _client.Execute(request);
        
            if (!response.IsSuccessful) throw new InternalAPIException(response);
        
            return true;
        }
        
        private class InternalAPIException : Exception
        {
            public InternalAPIException(RestResponse response) : base(
                $"API ERROR: Api sie poslizgnelo i pozdrawia z ziemi: {response.ErrorMessage} | Exception: {response.ErrorException}")
            {
            
            }
        }
        
        
        #region internal methods
        
        public static user addUser(string displayName, string token)
        {
            RestRequest request = new RestRequest("users/", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddBody(new { DisplayName=displayName });
                
            return Execute<user>(request);
        }

        public static user getMe(string userToken)
        {
            RestRequest request = new RestRequest("users/me", Method.Get);
            request.AddHeader("Authorization", $"Bearer {userToken}");
                
            return Execute<user>(request);
        }
        
        #endregion
    }
    
}