using System;
using System.Web.Mvc;
using Ttu.Presentation;
using Ttu.Presentation.Presenter;

namespace App.Controllers
{
    public class ProjectController : AbstractController
    {
        public ActionResult Index()
        {
            // Get all the "active" projects (projects whose stop time hasn't passed yet)
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ProjectPresenter presenter = presenterFactory.CreateProjectPresenter();
                return View(presenter.GetActiveProjectsByEndDate());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}