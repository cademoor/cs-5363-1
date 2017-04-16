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
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ProjectPresenter presenter = presenterFactory.CreateProjectPresenter();
                return View(presenter.GetProjects());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}