using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ttu.Presentation;

namespace App.Controllers
{
    public class ProjectApplicationController : AbstractController
    {
        // GET: ProjectApplication
        public ActionResult Index()
        {
            try
            {
                IPresenterFactory presenterFactory = ValidatePresenterFactory();
                ProjectApplicationPres
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        public ActionResult Index(int organizationId)
        {
            
        }
    }
}