namespace Contracts
{
    public interface IUnitofWork
    {
        IEventRepository Event { get; }

        void Save();
    }
}