using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ttu.Presentation;
using Ttu.Presentation.Presenter;

namespace App.Controllers
{
    public class ProjectApplicationController : AbstractController
    {
        // GET: ProjectApplication (by project)
        public ActionResult Index(int projectId)
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ProjectApplicationPresenter presenter = presenterFactory.CreateProjectApplicationPresenter();
                return View(presenter.GetProjectApplications(projectId));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }

        }
    }
}