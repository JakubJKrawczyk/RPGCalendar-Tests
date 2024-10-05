using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace RpgCalendar.ApiClients.InternalApi.Models;

    public class privateEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }
        public DateOnly StartingDay { get; set; }
        public DateOnly EndingDay { get; set; }
        public bool IsOnLine { get; set; } = false;
        public string eventLocation { get; set; }
    }