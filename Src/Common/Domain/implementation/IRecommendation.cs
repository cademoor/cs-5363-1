namespace Ttu.Domain
{
    public interface IRecommendation
    {

        int? ProbabilityRank { get; }
        int RecordId { get; }
        RecommendationType Type { get; }
        IUser User { get; }
        string Value { get; }

    }
}
