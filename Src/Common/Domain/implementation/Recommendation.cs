namespace Ttu.Domain
{
    public class Recommendation : IRecommendation
    {

        #region Constructors

        public Recommendation()
        {
            Rank = null;
            RecordId = 0;
            ReferenceId = 0;
            Type = RecommendationType.Unknown;
            User = null;
        }

        #endregion

        #region Properties

        public virtual double? Rank { get; set; }
        public virtual int RecordId { get; set; }
        public virtual int ReferenceId { get; set; }
        public virtual RecommendationType Type { get; set; }
        public virtual IUser User { get; set; }

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
