namespace Ttu.Domain
{
    public class NullUserService : IUserService
    {

        public static IUserService Singleton = new NullUserService();

        #region Constructors

        protected NullUserService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddUser(IUser user)
        {
            // do nothing
        }

        public virtual IUser GetUser(string userId)
        {
            return null;
        }

        public virtual IUser GetUser(int recordId)
        {
            return null;
        }

        public virtual IUser[] GetUsers()
        {
            return new IUser[0];
        }

        public virtual void RemoveUser(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveUser(IUser user)
        {
            // do nothing
        }

        public virtual bool UserNameExists(string userId)
        {
            return false; 
        }

        #endregion

    }
}
