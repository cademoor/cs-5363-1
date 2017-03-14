using System.Web;
using System.Web.Mvc;
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

            string sessionId = cookie.Value;
            IPresenterFactory presenterFactory = PresentationEnvironment.Singleton.ValidatePresenterFactory(sessionId);
            if (presenterFactory == null)
            {
                throw new System.Exception("A session has not been established");
            }

            return presenterFactory;
        }


        #endregion

    }
}
