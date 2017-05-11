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
            OrganizationService = CreateOrganizationService();
            Service = CreateRecommendationService();
        }

        #endregion

        #region Properties

        private IOrganizationService OrganizationService { get; set; }
        private IRecommendationService Service { get; set; }

        #endregion

        #region Public Methods

        public RecommendationModel[] GetRecommendations()
        {
            IRecommendation[] recommendations = Service.GetRecommendations().Where(r => r.ReferenceId > 0).OrderBy(r => r.Rank ?? 100000).ToArray();
            RecommendationModel[] recommendationModels = recommendations.Select(o => CreateRecommendationModel(o)).ToArray();
            return recommendationModels.Where(rm => rm != null).ToArray();
        }

        #endregion

        #region Helper Methods

        private RecommendationModel CreateRecommendationModel(IRecommendation recommendation)
        {
            // guard clause - no recommendation
            string recommendedValue = GetRecommendedValue(recommendation);
            if (recommendedValue == null)
            {
                return null;
            }

            RecommendationModel recommendationModel = new RecommendationModel();
            recommendationModel.CopyFrom(recommendation, recommendedValue);
            return recommendationModel;
        }

        private string GetRecommendedValue(IRecommendation recommendation)
        {
            if (recommendation.Type == RecommendationType.OrganizationToUser)
            {
                IOrganization organization = OrganizationService.GetOrganization(recommendation.ReferenceId);
                return organization == null ? null : organization.Name;
            }

            return null;
        }

        #endregion

    }
}
