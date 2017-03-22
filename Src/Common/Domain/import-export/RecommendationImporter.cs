using System;
using System.IO;
using System.Linq;

namespace Ttu.Domain
{
    public class RecommendationImporter
    {

        #region Constructors

        public RecommendationImporter(IServiceFactory serviceFactory, IUnitOfWork unitOfWork, string fullyQualifiedInputFilePath)
        {
            FullyQualifiedInputFilePath = fullyQualifiedInputFilePath;
            ServiceFactory = serviceFactory;
            UnitOfWork = unitOfWork;

            RecommendationService = serviceFactory.CreateRecommendationService(unitOfWork);
            UserService = serviceFactory.CreateUserService(unitOfWork);
        }

        #endregion

        #region Properties

        private string FullyQualifiedInputFilePath { get; set; }
        private IRecommendationService RecommendationService { get; set; }
        private IServiceFactory ServiceFactory { get; set; }
        private IUnitOfWork UnitOfWork { get; set; }
        private IUserService UserService { get; set; }

        #endregion

        #region Public Methods

        public void Import()
        {
            string[] fileLines = File.ReadAllLines(FullyQualifiedInputFilePath);
            fileLines.ToList().ForEach(line => ImportRecommendation(line));
            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // TODO:ACM - need to add/update here (should we just delete and re-add)
        }

        #endregion

        #region Helper Methods

        private void ImportRecommendation(string fileLine)
        {
            string[] splitLine = fileLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length != 5)
            {
                return;
            }

            int? recordId = ToInt(splitLine[0], null);
            int? userRecordId = ToInt(splitLine[1], null);
            int? probabilityRank = ToInt(splitLine[2], null);
            string value = splitLine[3];
            RecommendationType recommendationType = (RecommendationType)ToInt(splitLine[2], (int)RecommendationType.Unknown);

            if (!recordId.HasValue || !userRecordId.HasValue || recommendationType == RecommendationType.Unknown)
            {
                return;
            }

            Recommendation recommendation = new Recommendation();
            recommendation.ProbabilityRank = probabilityRank;
            recommendation.RecordId = recordId.Value;
            recommendation.Type = recommendationType;
            recommendation.User = UserService.GetUser(userRecordId.Value);
            recommendation.Value = value;

            RecommendationService.AddRecommendation(recommendation);
        }

        private int? ToInt(string value, int? defaultValue)
        {
            int result;
            if (!Int32.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        private int ToInt(string value, int defaultValue)
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
