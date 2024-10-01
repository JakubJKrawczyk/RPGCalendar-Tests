using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public partial class InternalApiClient
{
    public partial class Users
    {
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
    }
    
}