using Ttu.Domain;

namespace Ttu.Service
{
    public class EntityService : AbstractService, IEntityService
    {

        #region Constructors

        public EntityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddEntity(IEntity entity)
        {
            UnitOfWork.Entitys.Add(entity);
        }

        public virtual IEntity GetEntity(int recordId)
        {
            return UnitOfWork.Entitys.FindByRecordId(recordId);
        }

        public virtual IEntity[] GetEntitys()
        {
            return UnitOfWork.Entitys.FindAll();
        }

        public virtual void RemoveEntity(int recordId)
        {
            // guard clause - not found
            IEntity entity = GetEntity(recordId);
            if (entity == null)
            {
                return;
            }

            UnitOfWork.Entitys.Remove(entity);
        }

        public virtual void RemoveEntity(IEntity entity)
        {
            // guard clause - invalid input
            if (entity == null)
            {
                return;
            }

            RemoveEntity(entity.RecordId);
        }

        #endregion

    }
}
