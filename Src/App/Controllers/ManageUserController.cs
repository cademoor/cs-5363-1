using System;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ManageUserController : AbstractController
    {
        public ActionResult Index()
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageUserPresenter presenter = presenterFactory.CreateManageUserPresenter();
                return View(presenter.GetUsers());
            }
            catch (NoSessionException)
            {
                return RedirectToAction("Login", "Account");
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
        public ActionResult Create(UserModel userModel)
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ManageUserPresenter presenter = presenterFactory.CreateManageUserPresenter();
                presenter.AddUser(userModel);

                return RedirectToAction("Index", "Project");
            }
            catch (NoSessionException)
            {
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
