using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ManageProjectController : AbstractController
    {
        // GET: ManageProject
        public ActionResult Index(int organizationId)
        {
            IPresenterFactory presenterFactory = ValidatePresenterFactory();
            ManageProjectPresenter presenter = presenterFactory.CreateManageProjectPresenter();
            return View(presenter.GetProjects(organizationId));
        }

        // GET: ManageProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageProject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageProject/Create
        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            try
            {
                int organizationId = projectModel.OrganizationId;
                IPresenterFactory presenterFactory = ValidatePresenterFactory();

                // Look up the OrganizationModel
                ManageOrganizationPresenter organizationPresenter = presenterFactory.CreateManageOrganizationPresenter();
                OrganizationModel organizationModel = organizationPresenter.GetOrganization(organizationId);
                if (organizationModel == null)
                {
                    throw new Exception("Unable to find organization with ID " + organizationId);
                }
                projectModel.OrganizationModel = organizationModel;

                ManageProjectPresenter presenter = presenterFactory.CreateManageProjectPresenter();
                presenter.AddProject(projectModel);

                return RedirectToAction("Index", new { organizationId = organizationId});
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ManageProject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageProject/Edit/5
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

        // GET: ManageProject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageProject/Delete/5
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