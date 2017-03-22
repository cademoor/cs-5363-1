using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
                ImportRecommendations(userService);
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

        private static void ImportRecommendation(IUserService userService, List<IRecommendation> recommendations, string fileLine)
        {
            string[] splitLine = fileLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length != 4)
            {
                return;
            }

            int? recordId = ToInt(splitLine[0], null);
            int? userRecordId = ToInt(splitLine[1], null);
            int? probabilityRank = ToInt(splitLine[2], null);
            string value = splitLine[3];

            if (!recordId.HasValue || !userRecordId.HasValue)
            {
                return;
            }

            Recommendation recommendation = new Recommendation();
            recommendation.ProbabilityRank = probabilityRank;
            recommendation.RecordId = recordId.Value;
            recommendation.User = userService.GetUser(userRecordId.Value);
            recommendation.Value = value;

            recommendations.Add(recommendation);
        }

        private static void ImportRecommendations(IUserService userService)
        {
            string fullPath = ApplicationEnvironment.Singleton.FullyQualifiedInputFilePath;
            string[] fileLines = File.ReadAllLines(fullPath);

            List<IRecommendation> recommendations = new List<IRecommendation>();
            fileLines.ForEach(line => ImportRecommendation(userService, recommendations, line));

            // TODO:ACM - need to add/update here (should we just delete and re-add)
            // I think we should also add a new enum that describes the recommendation type
        }

        private static IUnitOfWork Initialize(string[] args)
        {
            ApplicationEnvironment.Singleton.InitializeApplication(args);

            IServiceFactory serviceFactory = ApplicationEnvironment.Singleton.InitializeService();
            return serviceFactory.CreateAuthenticationService().CreateAdHocUnitOfWork();
        }

        private static int? ToInt(string value, int? defaultValue)
        {
            int result;
            if (!Int32.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        #endregion

    }
}
