namespace RpgCalendar.ApiClients.InternalApi.Models;

public record userCredentials(string username, string password, string token = "");

public class user
{
    public string displayName { get; set; }
    public string privateCode { get; set; }
    public Guid id { get; set; }
}