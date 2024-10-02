using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace RpgCalendar.ApiClients.InternalApi.Models;

    public class usersAbsences
    {
        public TimeSpan StartingHour { get; set; }
        public DateOnly StartingDay { get; set; }
        public DateOnly EndingDay { get; set; }
        public TimeSpan EndingHour { get; set; }
    }

    public class listEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }
        public DateOnly StartingDay { get; set; }
        public DateOnly EndingDay { get; set; }
    }

    public class privateEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }
        public DateOnly StartingDay { get; set; }
        public DateOnly EndingDay { get; set; }
        public bool IsOnLine { get; set; } =
            false; // Nie wiem czy dobrze ( według internetu "bool" jest lepsze od "Boolean" => reprezentuje tę samą wartość logiczną (truth/false), W TYM PRZYPADKU DOMYŚLNIE "false" 
        
        public string eventLocation { get; set; }
    }