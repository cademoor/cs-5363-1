namespace Ttu.Domain
{
    public class NullVolunteerOpportunityService : IVolunteerOpportunityService
    {

        public static IVolunteerOpportunityService Singleton = new NullVolunteerOpportunityService();

        #region Constructors

        protected NullVolunteerOpportunityService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddVolunteerOpportunity(IVolunteerOpportunity volunteerOpportunity)
        {
            // do nothing
        }

        public virtual IVolunteerOpportunityApplication[] GetAllApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return new IVolunteerOpportunityApplication[0];
        }

        public virtual IVolunteerOpportunityApplication[] GetApprovedApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return new IVolunteerOpportunityApplication[0];
        }

        public virtual IVolunteerOpportunityApplication[] GetDeniedApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return new IVolunteerOpportunityApplication[0];
        }

        public virtual IVolunteerOpportunityApplication[] GetSubmittedApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return new IVolunteerOpportunityApplication[0];
        }

        public virtual IVolunteerOpportunity[] GetVolunteerOpportunities()
        {
            return new IVolunteerOpportunity[0];
        }

        public virtual IVolunteerOpportunity[] GetVolunteerOpportunitiesCreatedBy(IUser user)
        {
            return new IVolunteerOpportunity[0];
        }

        public virtual IVolunteerOpportunity GetVolunteerOpportunity(int recordId)
        {
            return null;
        }

        public virtual IVolunteerOpportunity[] GetAllAppliedOpportunities(IUser user, OpportunityApplicationStatus status)
        {
            return new IVolunteerOpportunity[0];
        }

        public virtual IVolunteerOpportunity[] GetCurrentAppliedOpportunities(IUser user, OpportunityApplicationStatus status)
        {
            return new IVolunteerOpportunity[0];
        }

        public virtual IVolunteerOpportunity[] GetPreviousAppliedOpportunities(IUser user, OpportunityApplicationStatus status)
        {
            return new IVolunteerOpportunity[0];
        }

        public virtual void RemoveVolunteerOpportunity(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveVolunteerOpportunity(IVolunteerOpportunity volunteerOpportunity)
        {
            // do nothing
        }

        public virtual void Volunteer(IUser user, IVolunteerOpportunity volunteerOpportunity, string note)
        {
            // do nothing
        }

        #endregion

    }
}
