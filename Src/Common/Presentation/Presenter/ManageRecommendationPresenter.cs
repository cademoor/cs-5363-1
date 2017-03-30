using System.Linq;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageRecommendationPresenter : AbstractPresenter
    {

        #region Constructors

        public ManageRecommendationPresenter(ManageRecommendationViewState viewState)
            : base(viewState)
        {
            Service = CreateRecommendationService();
        }

        #endregion

        #region Properties

        private IRecommendationService Service { get; set; }

        #endregion

        #region Public Methods

        public void AddRecommendation(RecommendationModel recommendationModel)
        {
            // guard clause - invalid input
            if (recommendationModel == null)
            {
                return;
            }

            IRecommendation recommendation = new Recommendation();
            recommendationModel.ApplyTo(recommendation);

            Service.AddRecommendation(recommendation);
            Commit();
        }

        public RecommendationModel GetRecommendation(int recordId)
        {
            // guard clause - not found
            IRecommendation recommendation = Service.GetRecommendation(recordId);
            if (recommendation == null)
            {
                return null;
            }

            return CreateRecommendationModel(recommendation);
        }

        public RecommendationModel[] GetRecommendations()
        {
            return Service.GetRecommendations().Select(o => CreateRecommendationModel(o)).ToArray();
        }

        public void RemoveRecommendation(RecommendationModel recommendationModel)
        {
            // guard clause - invalid input
            if (recommendationModel == null)
            {
                return;
            }

            Service.RemoveRecommendation(recommendationModel.RecordId);
            Commit();
        }

        #endregion

        #region Helper Methods

        private RecommendationModel CreateRecommendationModel(IRecommendation recommendation)
        {
            RecommendationModel recommendationModel = new RecommendationModel();
            recommendationModel.CopyFrom(recommendation);
            return recommendationModel;
        }

        #endregion

    }
}
