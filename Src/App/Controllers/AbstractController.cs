using System;
using System.Web;
using System.Web.Mvc;
using Ttu.Domain;
using Ttu.Presentation;

namespace App.Controllers
{
    public class AbstractController : Controller
    {

        protected static readonly int SessionTimeoutMinutes = 5;

        #region Constructors

        protected AbstractController()
        {
        }

        #endregion

        #region Shared Methods

        protected void EndSession()
        {
            PersistCookie(null, DateTime.Now.AddMonths(-1));
        }

        protected ActionResult HandleException(Exception ex)
        {
            GetLogger().Error(ex);
            return View();
        }

        protected ActionResult HandleExceptionWarn(string message)
        {
            GetLogger().Warn(message);
            return View();
        }

        protected void PersistCookie(string sessionId)
        {
            PersistCookie(sessionId, DateTime.Now.AddMinutes(SessionTimeoutMinutes));
        }

        protected void PersistCookie(string sessionId, DateTime expirationDate)
        {
            HttpCookie existingCookie = Request.Cookies.Get(Ttu.Domain.Constants.COOKIE_NAME);
            if (existingCookie != null)
            {
                ApplicationLogger.GetLogger(GetType()).Info(string.Format("Existing Cookie Session ID: {0}", existingCookie.Value));
                existingCookie.Value = sessionId;
                existingCookie.Expires = expirationDate;
                Response.Cookies.Set(existingCookie);
                ApplicationLogger.GetLogger(GetType()).Info(string.Format("Update Cookie Session ID: {0}", sessionId));
            }
            else
            {
                HttpCookie cookie = new HttpCookie(Ttu.Domain.Constants.COOKIE_NAME);
                cookie.Value = sessionId;
                cookie.Expires = expirationDate;
                Response.Cookies.Add(cookie);
                ApplicationLogger.GetLogger(GetType()).Info(string.Format("New Cookie Session ID: {0}", sessionId));
            }
        }

        protected IPresenterFactory ValidatePresenterFactory()
        {
            HttpCookie cookie = Request.Cookies.Get(Ttu.Domain.Constants.COOKIE_NAME);
            if (cookie == null)
            {
                throw new System.Exception("A session has not been established");
            }

            cookie.Expires = DateTime.Now.AddMinutes(5);

            PersistCookie(cookie);

            string sessionId = cookie.Value;
            IPresenterFactory presenterFactory = PresentationEnvironment.Singleton.ValidatePresenterFactory(sessionId);
            if (presenterFactory == null)
            {
                throw new System.Exception("A session has not been established");
            }

            return presenterFactory;
        }

        #endregion

        #region Helper Methods

        private IApplicationLogger GetLogger()
        {
            return ApplicationLogger.GetLogger(GetType());
        }

        private void PersistCookie(HttpCookie existingCookie)
        {
            // guard clause - no cookie
            if (existingCookie == null)
            {
                return;
            }

            existingCookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Set(existingCookie);
            ApplicationLogger.GetLogger(GetType()).Info(string.Format("Refresh Cookie Timestamp: {0}", existingCookie.Value));
        }

        #endregion

    }
}
