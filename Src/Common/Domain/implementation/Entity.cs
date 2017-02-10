namespace Ttu.Domain
{
    public class Entity : IEntity
    {

        # region Constructors

        public Entity()
        {
            Property1 = string.Empty;
            Property2 = string.Empty;
            Property3 = string.Empty;
            RecordId = 0;
        }

        # endregion

        # region Properties

        public virtual string Property1 { get; set; }
        public virtual string Property2 { get; set; }
        public virtual string Property3 { get; set; }
        public virtual int RecordId { get; set; }

        # endregion

    }
}
