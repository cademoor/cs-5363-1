namespace Ttu.Domain
{
    public interface IVolunteerOpportunityApplication
    {

        // attributes
        IUser LastChangeStatusUser { get; }
        string Note { get; set; }
        OpportunityApplicationStatus Status { get; }
        IUser User { get; }
        IVolunteerOpportunity VolunteerOpportunity { get; }

        // behavior
        void ChangeStatus(IUser user, OpportunityApplicationStatus status);
        bool IsCurrent();
        bool IsPrevious();

    }
}
