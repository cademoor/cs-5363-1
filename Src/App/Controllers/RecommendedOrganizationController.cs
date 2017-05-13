using System;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class RecommendedOrganizationController : AbstractController
    {

        // GET: RecommendedOrganization
        public ActionResult Index()
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageRecommendationPresenter presenter = presenterFactory.CreateManageRecommendationPresenter();
                return View(presenter.GetRecommendations());
            }
            catch (NoSessionException)
            {
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}