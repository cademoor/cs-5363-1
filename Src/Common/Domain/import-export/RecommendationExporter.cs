using System;
using System.Linq;

namespace Ttu.Domain
{
    public class RecommendationExporter
    {

        #region Constructors

        public RecommendationExporter(IServiceFactory serviceFactory, IUnitOfWork unitOfWork, string fullyQualifiedOutputFilePath)
        {
            FullyQualifiedOutputFilePath = fullyQualifiedOutputFilePath;
            ServiceFactory = serviceFactory;

            RecommendationService = serviceFactory.CreateRecommendationService(unitOfWork);
        }

        #endregion

        #region Properties

        private string FullyQualifiedOutputFilePath { get; set; }
        private IRecommendationService RecommendationService { get; set; }
        private IServiceFactory ServiceFactory { get; set; }

        #endregion

        #region Public Methods

        public void Export()
        {
            IRecommendation[] recommendations = RecommendationService.GetRecommendations();
            WriteRecommendations(recommendations);
        }

        #endregion

        #region Helper Methods

        private void WriteRecommendation(FileWriter fw, IRecommendation recommendation)
        {
            fw.PrintLine("{0},{1},{2}", recommendation.RecordId, recommendation.User.RecordId, recommendation.ProbabilityRank ?? -1);
        }

        private void WriteRecommendations(IRecommendation[] recommendations)
        {
            FileWriter fw = FileWriter.CreateFile(FullyQualifiedOutputFilePath);
            if (fw == null)
            {
                return;
            }

            try
            {
                recommendations.ToList().ForEach(r => WriteRecommendation(fw, r));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                fw.Close();
            }
        }

        #endregion

    }
}
