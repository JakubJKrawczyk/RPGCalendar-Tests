
using System.Buffers.Text;

namespace RpgCalendar.ApiClients.InternalApi.Models;

public class group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public group(string name, string profilePicture)
    {
        Id = Guid.NewGuid();
        Name = name;
        ProfilePicture = profilePicture;
        CreatedAt = DateTime.UtcNow;
    }
}

