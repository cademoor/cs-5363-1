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
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        #region Helper Methods

        #endregion

    }
}
