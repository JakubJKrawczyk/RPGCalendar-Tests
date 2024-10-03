using System.Text.RegularExpressions;
using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public record Groups(List<group> GroupList);


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
            return ;
        }

        public void deleteGroup(Guid groupId)
        {
            return;
        }

        public List<user> getGroupUsers(Guid groupId)
        {
            return null;
        }

        public void addUserToGroup(Guid groupId, Guid userId)
        {
            
        }

        public string getInviteLink(Guid groupId)
        {
            return null;
        }

        public void deleteUserFromGroup(Guid groupId, Guid userId)
        {
            return;
        }
    }
}