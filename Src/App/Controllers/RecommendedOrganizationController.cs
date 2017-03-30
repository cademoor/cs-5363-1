using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class RecommendedOrganizationController : AbstractController
    {

        // GET: RecommendedOrganization
        public ActionResult Index()
        {
            IPresenterFactory presenterFactory = ValidatePresenterFactory();
            ManageRecommendationPresenter presenter = presenterFactory.CreateManageRecommendationPresenter();
            return View(presenter.GetRecommendations());
        }

    }
}