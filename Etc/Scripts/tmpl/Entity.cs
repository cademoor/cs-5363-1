using System;

namespace Ttu.Domain
{
    public class Entity : IEntity
    {

        #region Constructors

        public Entity()
        {
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual int RecordId { get; set; }

        #endregion

    }
}
