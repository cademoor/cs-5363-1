using System;
using System.Web;
using System.Web.Mvc;
using Ttu.Domain;
using Ttu.Presentation;
using Ttu.Presentation.Model;

namespace App.Controllers
{
    public class LogOnController : AbstractController
    {

        // GET: LogOn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogOn/Create
        [HttpPost]
        public ActionResult Create(LogOnModel logOnModel)
        {
            try
            {
                LogOnPresenter presenter = new LogOnPresenter(null);
                string sessionId = presenter.LogOn(logOnModel.UserId, logOnModel.Password);
                PersistCookie(sessionId);
                return RedirectToAction("Create", "ManageUser");
            }
            catch
            {
                return View();
            }
        }

        #region Helper Methods

        private void PersistCookie(string sessionId)
        {
            HttpCookie existingCookie = Request.Cookies.Get(Ttu.Domain.Constants.COOKIE_NAME);
            if (existingCookie != null)
            {
                ApplicationLogger.GetLogger(GetType()).Info(string.Format("Existing Cookie Session ID: {0}", existingCookie.Value));
                existingCookie.Value = sessionId;
                existingCookie.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Set(existingCookie);
                ApplicationLogger.GetLogger(GetType()).Info(string.Format("Update Cookie Session ID: {0}", sessionId));
            }
            else
            {
                HttpCookie cookie = new HttpCookie(Ttu.Domain.Constants.COOKIE_NAME);
                cookie.Value = sessionId;
                cookie.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Add(cookie);
                ApplicationLogger.GetLogger(GetType()).Info(string.Format("New Cookie Session ID: {0}", sessionId));
            }
        }

        #endregion

    }
}
