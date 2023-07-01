using Contracts;

using Entities;
using Entities.Models;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAccount(Event @object)
        {
            Create(@object);
        }

        public void DeleteAccount(Event @object)
        {
            Delete(@object);
        }

        public IEnumerable<Event> GetAllEvent()
        {
            return FindAll().ToList();
        }

        public Event GetEventById(Guid eventId)
        {
            return FindByCondition(e => e.Id.Equals(eventId)).FirstOrDefault();

        }

        public void UpdateAccount(Event @object)
        {
            Update(@object);
        }
    }
}
