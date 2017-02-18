namespace Ttu.Domain
{
    public interface IVolunteerProfileReview
    {

        string Notes { get; set; }
        int? Rating { get; set; }
        int RecordId { get; }
        IUser Reviewer { get; }

    }
}
