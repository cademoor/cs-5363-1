namespace Ttu.Domain
{
    public class NullUnitOfWork : IUnitOfWork
    {

        public static IUnitOfWork Singleton = new NullUnitOfWork();

        # region Constructors

        private NullUnitOfWork()
        {
        }

        # endregion

        # region Properties

        public IUnitOfWorkRepository<IUser> Users { get { return CreateUowRepository<IUser>(); } }

        # endregion

        # region Helper Methods

        private IUnitOfWorkRepository<T> CreateUowRepository<T>() where T : class
        {
            return NullUnitOfWorkRepository<T>.Singleton;
        }

        # endregion

    }
}
