using System;

namespace Ttu.Domain
{
    public interface IProject
    {

        // attributes
        IUser CreatedBy { get; set; }
        IOrganization Organization { get; set; }

        int RecordId { get; set; }

        string ProjectName { get; set; }
        string ProjectDescription { get; set; }

        DateTime StartTime { get; set; }
        DateTime StopTime { get; set; }

        int MinimumVolunteers { get; set; }
        int MaximumVolunteers { get; set; }

        // behavior
        bool IsCurrent();
        bool IsPrevious();

    }
}
