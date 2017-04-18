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
        IUnitOfWorkRepository<IOrganizationUser> OrganizationUsers { get; }
        IUnitOfWorkRepository<IProject> Projects { get; }
        IUnitOfWorkRepository<IRecommendation> Recommendations { get; }
        IUnitOfWorkRepository<IUser> Users { get; }
        IUnitOfWorkRepository<IProjectApplication> ProjectApplications { get; }
        IUnitOfWorkRepository<IVolunteerProfileReview> VolunteerProfileReviews { get; }
        IUnitOfWorkRepository<IVolunteerProfile> VolunteerProfiles { get; }

        // behavior
        void Abort();
        void Commit();
        void Release();
        void Reset();

    }
}
