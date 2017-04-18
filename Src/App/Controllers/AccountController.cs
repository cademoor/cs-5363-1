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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                LogOnPresenter presenter = new LogOnPresenter(null);
                IUnitOfWork uow = presenter.LogOn(logOnModel.UserId, logOnModel.Password);
                ConfigureSession(uow);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                LogOnPresenter presenter = presenterFactory.CreateLogOnPresenter();
                presenter.LogOff();
            }
            catch (Exception ex)
            {
                // Shouldn't get here, but likely means the user isn't logged in
                string message = string.Format("Unable to create/use logon presenter to log off: {0}", ex.Message);
                HandleExceptionWarn(message);
            }

            EndSession();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel registerUserModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                LogOnPresenter presenter = new LogOnPresenter(null);
                IUnitOfWork uow = presenter.RegisterUser(registerUserModel);
                ConfigureSession(uow);
                if (uow != null && uow.User != null)
                {
                    string sessionId = uow.SessionId;
                    Session["_userFirstName"] = uow.User.FirstName;
                    PersistCookie(sessionId);
                }
                return RedirectToAction("Create", "ManageUser");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        #region Helper Methods

        private void ConfigureSession(IUnitOfWork uow)
        {
            if (uow == null || uow.User == null)
            {
                EndSession();
                return;
            }

            string sessionId = uow.SessionId;
            PersistCookie(sessionId);

            Session["_userFirstName"] = GetDisplayName(uow);
            Session["_userId"] = uow.User.UserId;
        }

        private string GetDisplayName(IUnitOfWork uow)
        {
            string name = uow.User.FirstName;
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            return uow.User.UserId;
        }

        #endregion

    }
}