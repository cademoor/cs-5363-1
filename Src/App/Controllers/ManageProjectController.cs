using System;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ManageProjectController : AbstractController
    {
        public ActionResult Index(int organizationId)
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageProjectPresenter presenter = presenterFactory.CreateManageProjectPresenter();
                return View(presenter.GetProjects(organizationId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            try
            {
                int organizationId = projectModel.OrganizationId;
                IPresenterFactory presenterFactory = ValidatePresenterFactory();

                ManageProjectPresenter presenter = presenterFactory.CreateManageProjectPresenter();
                presenter.AddProject(projectModel);

                return RedirectToAction("Index", new { organizationId = organizationId });
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}