using System;
using Ttu.Domain;

namespace Ttu.RecommendationImporter
{
    public class Program
    {

        #region Entry Point

        public static void Main(string[] args)
        {
            IUnitOfWork uow = Initialize(args);
            Execute(uow);
        }

        #endregion

        #region Helper Methods

        private static void Execute(IUnitOfWork uow)
        {
            IServiceFactory serviceFactory = ApplicationEnvironment.Singleton.ServiceFactory;
            try
            {
                IUserService userService = serviceFactory.CreateUserService(uow);

                string path = ApplicationEnvironment.Singleton.FullyQualifiedInputFilePath;
                new Domain.RecommendationImporter(serviceFactory, uow, path).ImportRecommendations();

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                Environment.Exit(1);
            }
            finally
            {
                uow.Release();
            }
        }

        private static IUnitOfWork Initialize(string[] args)
        {
            ApplicationEnvironment.Singleton.InitializeApplication(args);

            IServiceFactory serviceFactory = ApplicationEnvironment.Singleton.InitializeService();
            return serviceFactory.CreateAuthenticationService().CreateAdHocUnitOfWork();
        }

        #endregion

    }
}
