namespace Ttu.Domain
{
    public interface IProjectApplication
    {

        // attributes
        IUser LastChangeStatusUser { get; set; }
        string Note { get; set; }
        ProjectApplicationStatus Status { get; set; }
        IUser User { get; set; }
        IProject Project { get; set; }

        int RecordId { get; set; }

        // behavior
        void ChangeStatus(IUser user, ProjectApplicationStatus status);
        bool IsCurrent();
        bool IsPrevious();

    }
}
