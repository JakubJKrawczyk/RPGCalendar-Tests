using System.Data;
using System.Text.RegularExpressions;
using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public record Groups(List<group> GroupList);

// Do weryfikacji czy jest wszystkow  porządku i czy czegoś nie brakuje?
// Pytanie czy do poszczególnych fukncji warto dodać obsługę błędów czy zapytanie się powiodło ?
// Dodałem również funkcję "public void addUserByInviteId(Guid inviteId)". Była opisana na ClickUp a tutaj jej brakowało.
public partial class InternalApiClient
{
    public class Groups
    {
        
        public List<group> getUserGroups(Guid userId)
        {
            RestRequest request = new RestRequest($"/groups/{userId}", Method.Get);
            
            var response = Execute<List<group>>(request);
            
           return response;
        }
        public group addGroup(string name, string profilePicture)
        {
            var newGroup = new group
            {
                Name = name,
                ProfilePicture = profilePicture
            };
            
            RestRequest request = new RestRequest("/groups", Method.Post);
            
            request.AddJsonBody(newGroup);
            
            var response = Execute<group>(request);
            
            return response;
        }

        public Group getUserGroup(Guid groupId)
        {
            RestRequest request = new RestRequest($"/groups/{groupId}", Method.Get);
            
            var groupResult = Execute<Group>(request);
            
            return groupResult;
        }

        public void updateGroup(group group)
        {
            RestRequest request = new RestRequest($"/groups/{group.Id}", Method.Patch);
            
            request.AddJsonBody(group);
            
            var respose = Execute(request);
        }

        public void deleteGroup(Guid groupId)
        {
            RestRequest request = new RestRequest($"/groups/{groupId}", Method.Delete);
            
            var response = Execute(request);
        }

        public List<user> getGroupUsers(Guid groupId)
        {
            RestRequest request = new RestRequest($"/users/{groupId}", Method.Get);
            
            var response = Execute<List<user>>(request);
            
            return response;
        }

        public void addUserToGroup(Guid groupId, Guid userId)
        {
            RestRequest request = new RestRequest($"/groups/{groupId}/users", Method.Post);
            
            var body = new
            {
                UserId = userId
            };
            
            request.AddJsonBody(body);
            
            var response = Execute(request);
        }

        public string getInviteLink(Guid groupId)
        {
            RestRequest request = new RestRequest($"/groups/{groupId}/users/invite/external", Method.Post);
            
            var response = Execute<inviteLinkResponse>(request);
            
            return response.InviteLink;
        }

        public void addUserByInviteId(Guid inviteId)
        {
            RestRequest request = new RestRequest($"/groups/{inviteId}/users", Method.Post);

            var response = Execute(request);
        }

        public void deleteUserFromGroup(Guid groupId, Guid userId)
        {
            RestRequest request = new RestRequest($"/groups/{groupId}/users/{userId}", Method.Delete);
            
            var response = Execute(request);
        }
    }
}