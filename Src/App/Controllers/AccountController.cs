using System;
using System.Web.Mvc;
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

            var presenter = new LogOnPresenter(null);
            var sessionId = presenter.LogOn(logOnModel.UserId, logOnModel.Password);
            PersistCookie(sessionId);

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

            var presenter = new LogOnPresenter(null);
            var sessionId = presenter.RegisterUser(registerUserModel);
            PersistCookie(sessionId);
            return RedirectToAction("Create", "ManageUser");
        }
    }
}