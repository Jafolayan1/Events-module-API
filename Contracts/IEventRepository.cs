using Entities.Models;

namespace Contracts
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvent();
        Event GetEventById(Guid eventId);
        void CreateAccount(Event @object);
        void UpdateAccount(Event @object);
        void DeleteAccount(Event @object);
    }
}