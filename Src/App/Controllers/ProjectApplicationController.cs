using System;
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
            catch (NoSessionException)
            {
                return RedirectToAction("Login", "Account");
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
                var projectApplicationPresenter = presenterFactory.CreateProjectApplicationPresenter();
                projectApplicationPresenter.Volunteer(recordId, note);
                return RedirectToAction("Index", "Project");
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}