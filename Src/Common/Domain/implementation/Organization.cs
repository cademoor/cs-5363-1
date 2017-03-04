namespace Ttu.Domain
{
    public class Organization : IOrganization
    {

        #region Constructors

        public Organization()
            : this(null, string.Empty)
        {
        }

        public Organization(IUser createdBy, string name)
        {
            CreatedBy = createdBy;
            Name = name;

            Description = string.Empty;
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual IUser CreatedBy { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual int RecordId { get; set; }

        #endregion

    }
}
