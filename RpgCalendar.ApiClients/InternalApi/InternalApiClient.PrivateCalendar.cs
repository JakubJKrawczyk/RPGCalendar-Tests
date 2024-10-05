using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

// Ta sama sytuacja co w przypadku InternalApiClient.Group.cs.
public partial class InternalApiClient
{
    public class PrivateCalendar
    {
        public List<usersAbsences> getUsersAbsences(Guid userId)
        {
            RestRequest request = new RestRequest($"/users/{userId}/calendar/absences", Method.Get);

            var response = Execute<List<usersAbsences>>(request);
            
            return response;
        }
        
        public List<privateEvent> getListEvents(Guid eventId, Guid userId)
        {
            RestRequest request = new RestRequest($"/users/{userId}/calendar/events/{eventId}", Method.Get);

            var response = Execute<List<privateEvent>>(request);

            return response;
        }

        public privateEvent addEvent(Guid eventId, Guid userId)
        {
            var newEvent = new privateEvent();
            
            RestRequest request = new RestRequest($"users/{userId}/calendar/events/{eventId}", Method.Post);
            
            request.AddJsonBody(newEvent);

            var response = Execute<privateEvent>(request);
            
            return response;
        }
        
        public void deleteEvent(Guid eventId, Guid userId)
        {
            RestRequest request = new RestRequest($"/users/{userId}/calendar/events/{eventId}", Method.Delete);
    
            var response = Execute(request);
        }

        public privateEvent updateEvent(Guid eventId, Guid userId)
        {
            var updatedEvent = new privateEvent();
            
            RestRequest request = new RestRequest($"users/{userId}/calendar/events/{eventId}", Method.Put);
            
            request.AddJsonBody(updatedEvent);
            
            var response = Execute<privateEvent>(request);
    
            return response;
        }

        public privateEvent modifyEvent(Guid eventId, Guid userId)
        {
            var modifyEvent = new privateEvent();
            
            RestRequest request = new RestRequest($"users/{userId}/calendar/events/{eventId}", Method.Put);
            
            request.AddJsonBody(modifyEvent);
            
            var response = Execute<privateEvent>(request);
    
            return response;
        }
    }
}