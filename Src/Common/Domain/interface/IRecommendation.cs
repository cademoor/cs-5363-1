namespace Ttu.Domain
{
    public interface IRecommendation
    {

        double? Rank { get; set; }
        int RecordId { get; }
        int ReferenceId { get; set; }
        RecommendationType Type { get; set; }
        IUser User { get; set; }

        string GetRecommendationType();

    }
}
