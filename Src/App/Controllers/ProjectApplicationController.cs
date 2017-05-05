using System;
using System.Linq;
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

        public ActionResult Apply(int projectId)
        {
            try
            {
                var presenterFactory = ValidatePresenterFactory();
                var presenter = presenterFactory.CreateProjectPresenter();
                var project = presenter.GetProject(projectId);
                return View(project);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public ActionResult Apply(int recordId, string note)
        {
            try
            {
                var presenterFactory = ValidatePresenterFactory();
                var projectPresenter = presenterFactory.CreateProjectPresenter();
                var project = projectPresenter.GetProject(recordId);
                var applicationPresenter = presenterFactory.CreateProjectApplicationPresenter();
                applicationPresenter.Volunteer(project, note);
                return RedirectToAction("Index", "Project");
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}