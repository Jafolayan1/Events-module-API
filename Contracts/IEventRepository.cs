using Entities.Models;

namespace Contracts
{
    public interface IEventRepository
    {
        PagedList<Event> GetAllEvent(EventParameters eventParameters);

        Event GetEventById(Guid eventId);

        void CreateEvent(Event @object);

        void UpdateEvent(Event @object);

        void DeleteEvent(Event @object);
    }
}