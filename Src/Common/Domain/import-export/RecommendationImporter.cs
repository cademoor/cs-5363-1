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
            UnitOfWork = unitOfWork;

            RecommendationService = serviceFactory.CreateRecommendationService(unitOfWork);
            UserService = serviceFactory.CreateUserService(unitOfWork);
        }

        #endregion

        #region Properties

        private string FullyQualifiedInputFilePath { get; set; }
        private IRecommendationService RecommendationService { get; set; }
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
        }

        #endregion

        #region Helper Methods

        private RecommendationType GetRecommendationType(string[] splitLine)
        {
            if (splitLine.Length == 0)
            {
                return RecommendationType.Unknown;
            }

            int? value = ToInt(splitLine[splitLine.Length - 1], null);
            if (!value.HasValue)
            {
                return RecommendationType.OrganizationToUser;
            }

            return RecommendationType.OrganizationToUser;
        }

        private void ImportOrganizationToUserRecommendation(string[] splitLine)
        {
            if (splitLine.Length != 3)
            {
                return;
            }

            int? userRecordId = ToInt(splitLine[0], null);
            int? referenceRecordId = ToInt(splitLine[1], null);
            double? probabilityRank = ToDouble(splitLine[2], null);
            RecommendationType recommendationType = RecommendationType.OrganizationToUser;

            if (!userRecordId.HasValue || !referenceRecordId.HasValue || !probabilityRank.HasValue || recommendationType == RecommendationType.Unknown)
            {
                return;
            }

            IRecommendation recommendation = RecommendationService.GetRecommendation(userRecordId.Value, referenceRecordId.Value) ?? new Recommendation();
            recommendation.Rank = probabilityRank;
            recommendation.ReferenceId = referenceRecordId.Value;
            recommendation.Type = recommendationType;
            recommendation.User = UserService.GetUser(userRecordId.Value);

            if (recommendation.RecordId == 0)
            {
                RecommendationService.AddRecommendation(recommendation);
            }
        }

        private void ImportRecommendation(string fileLine)
        {
            string[] splitLine = fileLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            RecommendationType recommendationType = GetRecommendationType(splitLine);
            if (recommendationType == RecommendationType.OrganizationToUser)
            {
                ImportOrganizationToUserRecommendation(splitLine);
            }
        }

        private double? ToDouble(string value, double? defaultValue)
        {
            double result;
            if (!Double.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
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

        #endregion

    }
}
