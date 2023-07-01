using Contracts;

using Entities;

namespace Repository
{
    public class UnitofWork : IUnitofWork
    {
        private RepositoryContext _repoContext;
        private IEventRepository _event = default!;

        public UnitofWork(RepositoryContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IEventRepository Event
        {
            get
            {
                _event ??= new EventRepository(_repoContext);
                return _event;
            }
        }

        public void Save() => _repoContext.SaveChangesAsync();
    }
}