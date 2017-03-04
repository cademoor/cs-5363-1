
namespace Ttu.Domain
{
    public class VolunteerOpportunityApplication : IVolunteerOpportunityApplication
    {

        #region Constructors

        public VolunteerOpportunityApplication()
            : this(null, null)
        {
        }

        public VolunteerOpportunityApplication(IUser user, IVolunteerOpportunity volunterrOpportunity)
        {
            User = user;
            VolunteerOpportunity = volunterrOpportunity;

            LastChangeStatusUser = null;
            Note = string.Empty;
            Status = OpportunityApplicationStatus.Submitted;
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual IUser LastChangeStatusUser { get; set; }

        public virtual string Note { get; set; }

        public virtual int RecordId { get; set; }

        public virtual OpportunityApplicationStatus Status { get; set; }

        public virtual IUser User { get; set; }

        public virtual IVolunteerOpportunity VolunteerOpportunity { get; set; }

        #endregion

        #region Public Methods

        public virtual void ChangeStatus(IUser user, OpportunityApplicationStatus status)
        {
            LastChangeStatusUser = user;
            Status = status;
        }

        public virtual bool IsCurrent()
        {
            // guard clause - invalid state
            if (VolunteerOpportunity == null)
            {
                return false;
            }

            return VolunteerOpportunity.IsCurrent();
        }

        public virtual bool IsPrevious()
        {
            // guard clause - invalid state
            if (VolunteerOpportunity == null)
            {
                return false;
            }

            return VolunteerOpportunity.IsPrevious();
        }

        #endregion

    }
}
