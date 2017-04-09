namespace Ttu.Domain
{
    public class Recommendation : IRecommendation
    {

        #region Constructors

        public Recommendation()
        {
            Rating = null;
            RecordId = 0;
            Type = RecommendationType.Unknown;
            User = null;
            Value = string.Empty;
        }

        #endregion

        #region Properties

        public virtual int? Rating { get; set; }
        public virtual int RecordId { get; set; }
        public virtual RecommendationType Type { get; set; }
        public virtual IUser User { get; set; }
        public virtual string Value { get; set; }

        #endregion

        #region Public Methods

        public virtual string GetRecommendationType()
        {
            switch (Type)
            {
                case RecommendationType.OrganizationToUser:
                    return "Organization To User";
                case RecommendationType.Unknown:
                default:
                    return "Unknown";
            }
        }

        #endregion

    }
}
