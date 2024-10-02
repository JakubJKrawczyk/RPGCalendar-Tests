
using System.Buffers.Text;

namespace RpgCalendar.ApiClients.InternalApi.Models;

public class group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string profilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
}