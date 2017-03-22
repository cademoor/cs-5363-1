using System;
using Ttu.Domain;

namespace Ttu.RecommendationExporter
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
                string path = ApplicationEnvironment.Singleton.FullyQualifiedOutputFilePath;
                new Domain.RecommendationExporter(serviceFactory, uow, path).Export();

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
