using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace RpgCalendar.ApiClients.InternalApi.Models;

public class usersAbsences {
    public TimeSpan startingHour { get; set; }
    public DateOnly startingDay { get; set; }
    public DateOnly endingDay { get; set; }
    public TimeSpan endingHour { get; set; }
}
public class listEvent {
    public string title { get; set; }
    public string description { get; set; }
    public TimeSpan startingHour { get; set; }
    public DateOnly startingDay { get; set; }
    public DateOnly endingDay { get; set; }
    public TimeSpan endingHour { get; set; }
}
public class addEvent {
    public Guid privateEventId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateOnly startingDay { get; set; }
    public DateOnly endingDay { get; set; }
    public Boolean isOnLine { get; set; } // Nie wiem czy dobrze
    public string eventLocation { get; set; }
}
public class deleteEvent {
    public Guid privateEventId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateOnly startingDay { get; set; }
    public DateOnly endingDay { get; set; }
    public Boolean isOnLine { get; set; } // Nie wiem czy dobrze
    public string eventLocation { get; set; }
}
public class modifyEvent {
    public string title { get; set; }
    public string description { get; set; }
    public DateOnly startingDay { get; set; }
    public DateOnly endingDay { get; set; }
    public Boolean isOnLine { get; set; } // Nie wiem czy dobrze
    public string eventLocation { get; set; }
}