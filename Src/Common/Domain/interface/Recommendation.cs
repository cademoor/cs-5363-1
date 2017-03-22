namespace Ttu.Domain
{
    public class Recommendation : IRecommendation
    {

        #region Constructors

        public Recommendation()
        {
            ProbabilityRank = null;
            RecordId = 0;
            Type = RecommendationType.Unknown;
            User = null;
            Value = string.Empty;
        }

        #endregion

        #region Properties

        public virtual int? ProbabilityRank { get; set; }
        public virtual int RecordId { get; set; }
        public virtual RecommendationType Type { get; set; }
        public virtual IUser User { get; set; }
        public virtual string Value { get; set; }

        #endregion

    }
}
