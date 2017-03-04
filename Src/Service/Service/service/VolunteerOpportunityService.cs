using System.Linq;
using Ttu.Domain;

namespace Ttu.Service
{
    public class VolunteerOpportunityService : AbstractService, IVolunteerOpportunityService
    {

        #region Constructors

        public VolunteerOpportunityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public void AddVolunteerOpportunity(IVolunteerOpportunity volunteerOpportunity)
        {
            UnitOfWork.VolunteerOpportunities.Add(volunteerOpportunity);
        }

        public IVolunteerOpportunityApplication[] GetAllApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return GetApplications(volunteerOpportunity, null);
        }

        public IVolunteerOpportunityApplication[] GetApprovedApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return GetApplications(volunteerOpportunity, OpportunityApplicationStatus.Approved);
        }

        public IVolunteerOpportunityApplication[] GetDeniedApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return GetApplications(volunteerOpportunity, OpportunityApplicationStatus.Denied);
        }

        public IVolunteerOpportunityApplication[] GetSubmittedApplications(IVolunteerOpportunity volunteerOpportunity)
        {
            return GetApplications(volunteerOpportunity, OpportunityApplicationStatus.Submitted);
        }

        public IVolunteerOpportunity[] GetVolunteerOpportunities()
        {
            return UnitOfWork.VolunteerOpportunities.FindAll();
        }

        public IVolunteerOpportunity[] GetVolunteerOpportunitiesCreatedBy(IUser user)
        {
            return UnitOfWork.VolunteerOpportunities.FindBy(vp => vp.CreatedBy == user);
        }

        public IVolunteerOpportunity GetVolunteerOpportunity(int recordId)
        {
            return UnitOfWork.VolunteerOpportunities.FindByRecordId(recordId);
        }

        public IVolunteerOpportunity[] GetAllAppliedOpportunities(IUser user, OpportunityApplicationStatus status)
        {
            return GetApplications(user, status);
        }

        public IVolunteerOpportunity[] GetCurrentAppliedOpportunities(IUser user, OpportunityApplicationStatus status)
        {
            return GetApplications(user, status).Where(a => a.IsCurrent()).ToArray();
        }

        public IVolunteerOpportunity[] GetPreviousAppliedOpportunities(IUser user, OpportunityApplicationStatus status)
        {
            return GetApplications(user, status).Where(a => a.IsPrevious()).ToArray();
        }

        public void RemoveVolunteerOpportunity(int recordId)
        {
            // guard clause - not found
            IVolunteerOpportunity volunteerOpportunity = GetVolunteerOpportunity(recordId);
            if (volunteerOpportunity == null)
            {
                return;
            }

            UnitOfWork.VolunteerOpportunities.Remove(volunteerOpportunity);
        }

        public void RemoveVolunteerOpportunity(IVolunteerOpportunity volunteerOpportunity)
        {
            // guard clause - invalid input
            if (volunteerOpportunity == null)
            {
                return;
            }

            RemoveVolunteerOpportunity(volunteerOpportunity.RecordId);
        }

        public void Volunteer(IUser user, IVolunteerOpportunity volunteerOpportunity, string note)
        {
            // guard clause - invalid input
            if (user == null || volunteerOpportunity == null)
            {
                return;
            }

            IVolunteerOpportunityApplication application = new VolunteerOpportunityApplication(user, volunteerOpportunity);
            application.Note = note;

            UnitOfWork.VolunteerOpportunityApplications.Add(application);
        }

        #endregion

        # region Helper Methods

        private IVolunteerOpportunity[] GetApplications(IUser user, OpportunityApplicationStatus status)
        {
            IQueryable<IVolunteerOpportunityApplication> volunteerOpportunityApplications = UnitOfWork.VolunteerOpportunityApplications.GetQueryable();
            return volunteerOpportunityApplications.Where(a => a.User == user && a.Status == status).Select(a => a.VolunteerOpportunity).ToArray();
        }

        private IVolunteerOpportunityApplication[] GetApplications(IVolunteerOpportunity volunteerOpportunity, OpportunityApplicationStatus? status)
        {
            IQueryable<IVolunteerOpportunityApplication> volunteerOpportunityApplications = UnitOfWork.VolunteerOpportunityApplications.GetQueryable();
            volunteerOpportunityApplications = volunteerOpportunityApplications.Where(a => a.VolunteerOpportunity == volunteerOpportunity);
            if (!status.HasValue)
            {
                return volunteerOpportunityApplications.ToArray();
            }

            return volunteerOpportunityApplications.Where(a => a.Status == status).ToArray();
        }

        #endregion

    }
}
