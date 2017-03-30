using Ttu.Domain;

namespace Ttu.Presentation
{
    public class RecommendationModel
    {

        #region Constructors

        public RecommendationModel()
        {
            DisplayType = string.Empty;
            Rating = null;
            RecordId = 0;
            Type = RecommendationType.Unknown;
            UserId = string.Empty;
            Value = string.Empty;
        }

        #endregion

        #region Properties

        public string DisplayType { get; set; }

        public int? Rating { get; set; }
        public int RecordId { get; set; }

        public RecommendationType Type { get; set; }

        public string UserId { get; set; }

        public string Value { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IRecommendation recommendation)
        {
            recommendation.Type = Type;
            recommendation.Rating = Rating;
            //recommendation.User = Name;
            recommendation.Value = Value;
        }

        public void CopyFrom(IRecommendation recommendation)
        {
            DisplayType = recommendation.GetRecommendationType();
            Rating = recommendation.Rating;
            RecordId = recommendation.RecordId;
            UserId = recommendation.User != null ? recommendation.User.UserId : "None Assigned";
        }

        #endregion

    }
}
