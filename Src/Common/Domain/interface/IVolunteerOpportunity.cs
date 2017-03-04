using System;

namespace Ttu.Domain
{
    public interface IVolunteerOpportunity
    {

        // attributes
        IUser CreatedBy { get; }

        int RecordId { get; }

        DateTime StartTime { get; set; }
        DateTime StopTime { get; set; }

        // behavior
        bool IsCurrent();
        bool IsPrevious();

    }
}
