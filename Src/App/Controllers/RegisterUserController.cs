using System;
using System.Web.Mvc;
using Ttu.Domain;
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
                IUnitOfWork uow = presenter.RegisterUser(registerUserModel);
                if (uow != null)
                {
                    PersistCookie(uow.SessionId);
                }

                return RedirectToAction("Create", "ManageUser");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
