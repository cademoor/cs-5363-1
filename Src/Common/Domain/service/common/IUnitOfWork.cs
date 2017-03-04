namespace Ttu.Domain
{
    public interface IUnitOfWork
    {

        // attributes - authenticated
        string SessionId { get; }
        IUser User { get; }

        // attributes - repository
        IUnitOfWorkRepository<IContact> Contacts { get; }
        IUnitOfWorkRepository<IOrganization> Organizations { get; }
        IUnitOfWorkRepository<IUser> Users { get; }
        IUnitOfWorkRepository<IVolunteerOpportunity> VolunteerOpportunities { get; }
        IUnitOfWorkRepository<IVolunteerOpportunityApplication> VolunteerOpportunityApplications { get; }
        IUnitOfWorkRepository<IVolunteerProfileReview> VolunteerProfileReviews { get; }
        IUnitOfWorkRepository<IVolunteerProfile> VolunteerProfiles { get; }

        // behavior
        void Abort();
        void Commit();
        void Release();
        void Reset();

    }
}
