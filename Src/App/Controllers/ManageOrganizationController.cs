using System;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ManageOrganizationController : AbstractController
    {
        public ActionResult Index()
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageOrganizationPresenter presenter = presenterFactory.CreateManageOrganizationPresenter();
                return View(presenter.GetOrganizations());
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
        public ActionResult Create(OrganizationModel organizationModel)
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageOrganizationPresenter presenter = presenterFactory.CreateManageOrganizationPresenter();
                presenter.AddOrganization(organizationModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
