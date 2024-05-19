namespace WebApplicationTechLead1.Domain.Models
{
    public class Eventos
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }

        public Eventos() { }

        public Eventos(Guid id, string eventName, string eventType, string eventDescription, DateTime eventDate)
        {
            Id = id;
            EventName = eventName;
            EventType = eventType;
            EventDescription = eventDescription;
            EventDate = eventDate;
        }

    }
}
