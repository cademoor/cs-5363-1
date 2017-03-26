namespace Ttu.Domain
{
    public interface IRecommendation
    {

        int? ProbabilityRank { get; set; }
        int RecordId { get; }
        RecommendationType Type { get; set; }
        IUser User { get; set; }
        string Value { get; set; }

    }
}
