using System;
using Ttu.Domain;
using Ttu.Service;

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
                string path = ApplicationEnvironment.Singleton.FullyQualifiedInputFilePath;
                new Domain.RecommendationImporter(serviceFactory, uow, path).Import();

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

            ApplicationEnvironment.Singleton.InitializeService();
            return CreateAdHocUnitOfWork();
        }

        private static IUnitOfWork CreateAdHocUnitOfWork()
        {
            SessionDecorator openSession = ServiceEnvironment.Singleton.OpenSession();
            return new UnitOfWork(openSession, null);
        }

        #endregion

    }
}
