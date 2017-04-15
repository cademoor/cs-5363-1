using System;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ManageOrganizationController : AbstractController
    {
        // GET: ManageOrganization
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

        // GET: ManageOrganization/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageOrganization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageOrganization/Create
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

        // GET: ManageOrganization/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageOrganization/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageOrganization/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageOrganization/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
