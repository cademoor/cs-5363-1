namespace Ttu.Domain
{
    public interface IUnitOfWork
    {

        IUnitOfWorkRepository<IUser> Users { get; }

    }
}
