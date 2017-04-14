using System;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ManageUserController : AbstractController
    {
        // GET: ManageUser
        public ActionResult Index()
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageUserPresenter presenter = presenterFactory.CreateManageUserPresenter();
                return View(presenter.GetUsers());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET: ManageUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageUser/Create
        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageUserPresenter presenter = presenterFactory.CreateManageUserPresenter();
                presenter.AddUser(userModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET: ManageUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageUser/Edit/5
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

        // GET: ManageUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageUser/Delete/5
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
