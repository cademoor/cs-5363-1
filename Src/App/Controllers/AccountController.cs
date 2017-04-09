using System;
using System.Web.Mvc;
using Ttu.Domain;
using Ttu.Presentation;
using Ttu.Presentation.Model;

namespace App.Controllers
{
    public class AccountController : AbstractController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnModel logOnModel)
        {
            if (!ModelState.IsValid)
                return View();

            LogOnPresenter presenter = new LogOnPresenter(null);
            IUnitOfWork uow = presenter.LogOn(logOnModel.UserId, logOnModel.Password);
            string sessionId = uow.SessionId;
            PersistCookie(sessionId);
            //Cookie was created, store User to a session variable 
            if (uow != null && uow.User != null)
            {
                Session["_userFirstName"] = uow.User.FirstName;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            PersistCookie(null, DateTime.Now.AddMinutes(-5));
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel registerUserModel)
        {
            if (!ModelState.IsValid)
                return View();

            LogOnPresenter presenter = new LogOnPresenter(null);
            IUnitOfWork uow = presenter.RegisterUser(registerUserModel);
            if (uow != null && uow.User != null)
            {
                string sessionId = uow.SessionId;
                Session["_userFirstName"] = uow.User.FirstName;
                PersistCookie(sessionId);
            }
            return RedirectToAction("Create", "ManageUser");
        }
    }
}