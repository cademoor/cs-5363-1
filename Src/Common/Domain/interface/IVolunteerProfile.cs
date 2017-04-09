namespace Ttu.Domain
{
    public interface IVolunteerProfile
    {

        // attributes
        string Causes { get; set; } // TODO:ACM - make a 1:many

        string Description { get; set; }

        string Location { get; set; }

        string Name { get; set; }

        byte[] Photo { get; }

        int RecordId { get; }

        string Skills { get; set; } // TODO:ACM - make a 1:many

        IUser User { get; }

        // behavior
        void SetPhoto(byte[] photoBytes);
        void SetUser(IUser user);

    }
}
