using System.Text.Json;
using RestSharp;

namespace RpgCalendar.Utilities.Extensions;

public static class RestSharpExtensions
{
    public static string FromErrorMessage(this RestResponse response)
    {
        return $"""
                Error: {response.ErrorMessage} (ErrorCode: {response.StatusCode})
                
                Url: {response.Request.Method.ToString().ToUpper()} {response.ResponseUri}

                Response: {response.Content}

                Request: {string.Join("\n",response.Request.Parameters.Select(x => x.ToString()))}
                
                =======
                """;
    }
    
    public static void AddJson(this RestRequest request, object body) 
        => request.AddBody(JsonSerializer.Serialize(body), ContentType.Json);
}