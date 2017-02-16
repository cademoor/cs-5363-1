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

        public string SessionId { get { return string.Empty; } }
        public IUser User { get { return null; } }

        public IUnitOfWorkRepository<IContact> Contacts { get { return CreateUowRepository<IContact>(); } }
        public IUnitOfWorkRepository<IUser> Users { get { return CreateUowRepository<IUser>(); } }

        # endregion

        # region Public Methods

        public virtual void Abort()
        {
            // do nothing
        }

        public virtual void Commit()
        {
            // do nothing
        }

        public virtual void Release()
        {
            // do nothing
        }

        # endregion

        # region Helper Methods

        private IUnitOfWorkRepository<T> CreateUowRepository<T>() where T : class
        {
            return NullUnitOfWorkRepository<T>.Singleton;
        }

        # endregion

    }
}
