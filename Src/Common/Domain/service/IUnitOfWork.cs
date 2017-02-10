namespace Ttu.Domain
{
    public interface IUnitOfWork
    {

        IUnitOfWorkRepository<IEntity> Entities { get; }

    }
}
