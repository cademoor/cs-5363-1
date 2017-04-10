using System;
using System.Collections;
using System.Collections.Generic;

namespace Ttu.Domain
{
    public interface IVolunteerOpportunity
    {

        // attributes

        // Who created this project
        IUser CreatedBy { get; set; }
        IOrganization Organization { get; set; }

        int RecordId { get; }

        string ProjectName { get; set; }
        string ProjectDescription { get; set; }

        DateTime StartTime { get; set; }
        DateTime StopTime { get; set; }

        int NumVolunteersNeeded { get; set; }
        int MaxNumVolunteers { get; set; }

        // behavior
        bool IsCurrent();
        bool IsPrevious();

    }
}
