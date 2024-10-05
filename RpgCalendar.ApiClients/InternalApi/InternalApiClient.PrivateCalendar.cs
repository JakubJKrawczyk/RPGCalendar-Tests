using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public partial class InternalApiClient
{
    public class PrivateCalendar
    {
        public List<absence> getUsersAbsences(Guid userId)
        {
            RestRequest request = new RestRequest($"/users/{userId}/calendar/absences", Method.Get);

            var response = Execute<List<absence>>(request);
            
            return response;
        }
        
        public List<privateEvent> getListEvents(Guid userId)
        {
            RestRequest request = new RestRequest($"/users/{userId}/calendar/events/", Method.Get);

            var response = Execute<List<privateEvent>>(request);

            return response;
        }

        public privateEvent addEvent(Guid eventId, Guid userId)
        {
            var newEvent = new privateEvent();
            
            RestRequest request = new RestRequest($"users/{userId}/calendar/events/{eventId}", Method.Post);
            
            request.AddBody(newEvent);

            var response = Execute<privateEvent>(request);
            
            return response;
        }
        
        public void deleteEvent(Guid eventId, Guid userId)
        {
            RestRequest request = new RestRequest($"/users/{userId}/calendar/events/{eventId}", Method.Delete);
    
            var response = Execute(request);
        }

        public privateEvent updateEvent(privateEvent Event, Guid userId)
        {
            var updatedEvent = new privateEvent();
            
            RestRequest request = new RestRequest($"users/{userId}/calendar/events/{Event.Id}", Method.Put);
            
            request.AddBody(updatedEvent);
            
            var response = Execute<privateEvent>(request);
    
            return response;
        }

        public privateEvent modifyEvent(privateEvent Event, Guid userId)
        {
            RestRequest request = new RestRequest($"users/{userId}/calendar/events/{Event.Id}", Method.Put);
            
            request.AddBody(modifyEvent);
            
            var response = Execute<privateEvent>(request);
    
            return response;
        }
    }
}