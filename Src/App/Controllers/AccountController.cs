using System;
using System.Web;
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
            var cookie = Request.Cookies.Get(Ttu.Domain.Constants.COOKIE_NAME);
            if (cookie == null)
            {
                var newCookie = new HttpCookie(Ttu.Domain.Constants.COOKIE_NAME);
                newCookie.Expires = DateTime.MinValue;
                Response.Cookies.Add(newCookie);
            }
            else
            {
                cookie.Expires = DateTime.MinValue;
                Response.Cookies.Set(cookie);
            }

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