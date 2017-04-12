namespace Ttu.Domain
{
    public interface IProjectApplication
    {

        // attributes
        IUser LastChangeStatusUser { get; }
        string Note { get; set; }
        ProjectApplicationStatus Status { get; }
        IUser User { get; }
        IProject Project { get; }

        // behavior
        void ChangeStatus(IUser user, ProjectApplicationStatus status);
        bool IsCurrent();
        bool IsPrevious();

    }
}
