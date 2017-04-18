using System;
using System.IO;
using System.Linq;

namespace Ttu.Domain
{
    public class RecommendationExporter : AbstractApplicationLogger
    {

        #region Constructors

        public RecommendationExporter(IServiceFactory serviceFactory, IUnitOfWork unitOfWork, string fullyQualifiedOutputFilePath)
        {
            FullyQualifiedOutputFilePath = fullyQualifiedOutputFilePath;

            OrganizationService = serviceFactory.CreateOrganizationService(unitOfWork);
            RecommendationService = serviceFactory.CreateRecommendationService(unitOfWork);
        }

        #endregion

        #region Properties

        private string FullyQualifiedOutputFilePath { get; set; }
        private IOrganizationService OrganizationService { get; set; }
        private IRecommendationService RecommendationService { get; set; }

        #endregion

        #region Public Methods

        public void Export()
        {
            IRecommendation[] recommendations = RecommendationService.GetRecommendations();
            WriteRecommendations(recommendations);
        }

        #endregion

        #region Helper Methods

        private FileWriter CreateFileWriter()
        {
            if (!File.Exists(FullyQualifiedOutputFilePath))
            {
                return FileWriter.CreateFile(FullyQualifiedOutputFilePath);
            }

            try
            {
                File.Delete(FullyQualifiedOutputFilePath);
                return FileWriter.CreateFile(FullyQualifiedOutputFilePath);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        private void WriteOrganizationToUserRecommendation(FileWriter fw, IRecommendation recommendation)
        {
            // guard clause - invalid recommendation (user)
            IUser user = recommendation.User;
            if (user == null)
            {
                return;
            }

            // guard clause - invalid recommendation (organization)
            IOrganization organization = OrganizationService.GetOrganization(recommendation.ReferenceId);
            if (organization == null)
            {
                return;
            }

            int userRecordId = user.RecordId;
            int organizationRecordId = organization.RecordId;

            fw.PrintLine("{0},{1}", userRecordId, organizationRecordId);
        }

        private void WriteRecommendation(FileWriter fw, IRecommendation recommendation)
        {
            if (recommendation.Type == RecommendationType.OrganizationToUser)
            {
                WriteOrganizationToUserRecommendation(fw, recommendation);
            }
        }

        private void WriteRecommendations(IRecommendation[] recommendations)
        {
            FileWriter fw = CreateFileWriter();
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
