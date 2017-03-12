using System;
using System.Web;
using System.Web.Mvc;
using Ttu.Presentation;
using Ttu.Presentation.Model;

namespace App.Controllers
{
    public class LogOnController : AbstractController
    {
        // GET: LogOn
        public ActionResult Index()
        {
            return View();
        }

        // GET: LogOn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: LogOn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogOn/Edit/5
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

        // GET: LogOn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogOn/Delete/5
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

        #region Helper Methods

        private void PersistCookie(string sessionId)
        {
            HttpCookie cookie = new HttpCookie(Ttu.Domain.Constants.COOKIE_NAME);
            cookie.Value = sessionId;
            cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.SetCookie(cookie);
            Response.Flush();
        }

        #endregion

    }
}
