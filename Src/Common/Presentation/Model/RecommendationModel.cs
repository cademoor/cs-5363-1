using Ttu.Domain;

namespace Ttu.Presentation
{
    public class RecommendationModel
    {

        #region Constructors

        public RecommendationModel()
        {
            UserId = string.Empty;
            Value = string.Empty;
        }

        #endregion

        #region Properties

        public string UserId { get; set; }
        public string Value { get; set; }

        #endregion

        #region Public Methods

        public void CopyFrom(IRecommendation recommendation, string value)
        {
            UserId = recommendation.User != null ? recommendation.User.UserId : "None Assigned";
            Value = value ?? "None Assigned";
        }

        #endregion

    }
}
