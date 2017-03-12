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
            Location = null;
            MissionStatement = string.Empty;
            Name = string.Empty;
            RecordId = 0;
            Website = string.Empty;
        }

        #endregion

        #region Properties

        public virtual IContact Contact { get; set; }
        public virtual IUser CreatedBy { get; set; }

        public virtual string Description { get; set; }

        public virtual ILocation Location { get; set; }

        public virtual string MissionStatement { get; set; }

        public virtual string Name { get; set; }

        public virtual int RecordId { get; set; }

        public virtual string Website { get; set; }

        #endregion

    }
}
