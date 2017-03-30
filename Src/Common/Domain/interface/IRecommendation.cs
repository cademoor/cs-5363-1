namespace Ttu.Domain
{
    public interface IRecommendation
    {

        int? Rating { get; set; }
        int RecordId { get; }
        RecommendationType Type { get; set; }
        IUser User { get; set; }
        string Value { get; set; }

        string GetRecommendationType();

    }
}
