namespace Ttu.Domain
{
    public class NullUnitOfWork : IUnitOfWork
    {

        public static IUnitOfWork Singleton = new NullUnitOfWork();

        #region Constructors

        protected NullUnitOfWork()
        {
        }

        #endregion

        #region Properties

        public virtual string SessionId { get; set; }
        public virtual IUser User { get; set; }

        public virtual IUnitOfWorkRepository<IContact> Contacts { get { return CreateUowRepository<IContact>(); } }
        public virtual IUnitOfWorkRepository<IUser> Users { get { return CreateUowRepository<IUser>(); } }
        public virtual IUnitOfWorkRepository<IVolunteerProfile> VolunteerProfiles { get { return CreateUowRepository<IVolunteerProfile>(); } }

        #endregion

        #region Public Methods

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

        #endregion

        #region Helper Methods

        private IUnitOfWorkRepository<T> CreateUowRepository<T>() where T : class
        {
            return NullUnitOfWorkRepository<T>.Singleton;
        }

        #endregion

    }
}
