namespace Ttu.Domain
{
    public class NullEntityService : IEntityService
    {

        public static IEntityService Singleton = new NullEntityService();

        #region Constructors

        protected NullEntityService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddEntity(IEntity entity)
        {
            // do nothing
        }

        public virtual IEntity GetEntity(int recordId)
        {
            return null;
        }

        public virtual IEntity[] GetEntitys()
        {
            return new IEntity[0];
        }

        public virtual void RemoveEntity(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveEntity(IEntity entity)
        {
            // do nothing
        }

        #endregion

    }
}
