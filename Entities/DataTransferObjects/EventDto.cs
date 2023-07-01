namespace Entities.DataTransferObjects
{
    public class EventDto : BaseEventDto
    {
        public Guid Id { get; set; }
    }

    public class CreateEventDto : BaseEventDto
    {
    }

    public class UpdateEventDto : BaseEventDto
    {
    }

    public class BaseEventDto
    {
        public string EventTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public string EventDescription { get; set; }
    }
}