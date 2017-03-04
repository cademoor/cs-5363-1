namespace Ttu.Domain
{
    public interface IVolunteerOpportunityService
    {

        void AddVolunteerOpportunity(IVolunteerOpportunity volunteerOpportunity);

        IVolunteerOpportunityApplication[] GetAllApplications(IVolunteerOpportunity volunteerOpportunity);
        IVolunteerOpportunityApplication[] GetApprovedApplications(IVolunteerOpportunity volunteerOpportunity);
        IVolunteerOpportunityApplication[] GetDeniedApplications(IVolunteerOpportunity volunteerOpportunity);
        IVolunteerOpportunityApplication[] GetSubmittedApplications(IVolunteerOpportunity volunteerOpportunity);

        IVolunteerOpportunity[] GetVolunteerOpportunities();
        IVolunteerOpportunity[] GetVolunteerOpportunitiesCreatedBy(IUser user);
        IVolunteerOpportunity GetVolunteerOpportunity(int recordId);
        IVolunteerOpportunity[] GetAllAppliedOpportunities(IUser user, OpportunityApplicationStatus status);
        IVolunteerOpportunity[] GetCurrentAppliedOpportunities(IUser user, OpportunityApplicationStatus status);
        IVolunteerOpportunity[] GetPreviousAppliedOpportunities(IUser user, OpportunityApplicationStatus status);

        void RemoveVolunteerOpportunity(int recordId);
        void RemoveVolunteerOpportunity(IVolunteerOpportunity volunteerOpportunity);

        void Volunteer(IUser user, IVolunteerOpportunity volunteerOpportunity, string note);

    }
}
