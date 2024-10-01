using RestSharp;
using RpgCalendar.ApiClients.InternalApi.Models;

namespace RpgCalendar.ApiClients.InternalApi;

public partial class InternalApiClient
{
    public static InternalApiClient Instance { get; } = new InternalApiClient();

    protected static RestClient _client => new RestClient("https://dev.rpg-calendar.jakubkrawczyk.com", options =>
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
        
    public class InternalAPIException : Exception
    {
        public InternalAPIException(RestResponse response) : base(
            $"API ERROR: Api sie poslizgnelo i pozdrawia z ziemi: {response.ErrorMessage} | Exception: {response.ErrorException}")
        {
            
        }
    }
    
    
}