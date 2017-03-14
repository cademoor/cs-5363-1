using System;
using System.Web;
using System.Web.Mvc;
using Ttu.Domain;
using Ttu.Presentation;

namespace App.Controllers
{
    public class AbstractController : Controller
    {

        #region Constructors

        protected AbstractController()
        {
        }

        #endregion

        #region Public Methods

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
