using NHibernate.Linq;
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
                IRecommendationService recommendationService = serviceFactory.CreateRecommendationService(uow);
                IRecommendation[] recommendations = recommendationService.GetRecommendations();
                WriteRecommendations(recommendations);
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

        private static void WriteRecommendation(FileWriter fw, IRecommendation recommendation)
        {
            fw.PrintLine("{0},{1},{2}", recommendation.RecordId, recommendation.User.RecordId, recommendation.ProbabilityRank ?? -1);
        }

        private static void WriteRecommendations(IRecommendation[] recommendations)
        {
            string fullPath = ApplicationEnvironment.Singleton.FullyQualifiedOutputFilePath;
            FileWriter fw = FileWriter.CreateFile(fullPath);
            if (fw == null)
            {
                return;
            }

            recommendations.ForEach(r => WriteRecommendation(fw, r));

            fw.Close();
        }

        #endregion

    }
}
