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

        public void CreateEvent(Event @object)
        {
            Create(@object);
        }

        public void DeleteEvent(Event @object)
        {
            Delete(@object);
        }

        public PagedList<Event> GetAllEvent(EventParameters ownerParameters)
        {
            return PagedList<Event>.ToPagedList(FindAll().OrderBy(et => et.EventTitle),
                ownerParameters.PageNumber,
                ownerParameters.PageSize);
        }

        public Event GetEventById(Guid eventId)
        {
            return FindByCondition(e => e.Id.Equals(eventId)).FirstOrDefault();
        }

        public void UpdateEvent(Event @object)
        {
            Update(@object);
        }
    }
}