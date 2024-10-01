using System.Text.RegularExpressions;
using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public record Groups(List<group> GroupList);


public partial class InternalApiClient
{
    public partial class Groups
    {
        
        public List<group> getUserGroups()
        {
            RestRequest request = new RestRequest("/groups");

            var response = Execute<List<group>>(request);
            
           return response;
        }

        public Group addGroup()
        {
            return null;
        }

        public Group getUserGroup(Guid groupId)
        {
            return null;
        }

        public void updateGroup(group group)
        {
            return;
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