using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ttu.Domain;
using Ttu.Presentation;
using Ttu.Service;

namespace App
{
    public class MvcApplication : System.Web.HttpApplication
    {

        #region Event Handlers

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Environment.CurrentDirectory = HttpRuntime.AppDomainAppPath;
            InitializeApplication();
        }

        #endregion

        #region Helper Methods

        private IApplicationLogger GetLogger()
        {
            return ApplicationLogger.GetLogger(GetType());
        }

        private void InitializeAdminUser()
        {
            IUnitOfWork unitOfWork = NullUnitOfWork.Singleton;

            try
            {
                unitOfWork = PresentationEnvironment.Singleton.ServiceFactory.CreateAuthenticationService().CreateAdHocUnitOfWork();
                IUser adminUser = unitOfWork.Users.FindByUnique(u => u.UserId == Constants.USER_ID_ADMIN);
                if (adminUser == null)
                {
                    IUser newUser = new User(Constants.USER_ID_ADMIN);
                    newUser.SetPassword("1");

                    unitOfWork.Users.Add(newUser);
                    unitOfWork.Commit();
                }
            }
            finally
            {
                unitOfWork.Release();
            }

        }

        private void InitializeApplication()
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                InitializeDatabase();
                InitializeServiceFactory();
                InitializeAdminUser();
            }
            catch (Exception e)
            {
                GetLogger().Error(e);
            }
        }

        private void InitializeDatabase()
        {
            new ServiceInitializer().Initialize(false, false);
        }

        private void InitializeServiceFactory()
        {
            PresentationEnvironment.Singleton.SetServiceFactory(new ServiceFactory());
        }

        #endregion

    }
}
