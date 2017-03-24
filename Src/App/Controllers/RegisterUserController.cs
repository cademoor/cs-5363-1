using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class RegisterUserController : AbstractController
    {
        // GET: RegisterUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterUser/Create
        [HttpPost]
        public ActionResult Create(RegisterUserModel registerUserModel)
        {
            try
            {
                LogOnPresenter presenter = new LogOnPresenter(null);
                string sessionId = presenter.RegisterUser(registerUserModel);
                PersistCookie(sessionId);
                return RedirectToAction("Create", "ManageUser");
            }
            catch
            {
                return View();
            }
        }

    }
}
