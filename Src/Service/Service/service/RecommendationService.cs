using Ttu.Domain;

namespace Ttu.Service
{
    public class RecommendationService : AbstractService, IRecommendationService
    {

        #region Constructors

        public RecommendationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddRecommendation(IRecommendation recommendation)
        {
            UnitOfWork.Recommendations.Add(recommendation);
        }

        public virtual IRecommendation GetRecommendation(int recordId)
        {
            return UnitOfWork.Recommendations.FindByRecordId(recordId);
        }

        public virtual IRecommendation GetRecommendation(int userRecordId, int referenceRecordId)
        {
            return UnitOfWork.Recommendations.FindByUnique(r => r.User.RecordId == userRecordId && r.ReferenceId == referenceRecordId);
        }

        public virtual IRecommendation[] GetRecommendations()
        {
            return UnitOfWork.Recommendations.FindAll();
        }

        public virtual IRecommendation[] GetRecommendations(IUser user)
        {
            return UnitOfWork.Recommendations.FindBy(c => c.User == user);
        }

        public virtual void RemoveRecommendation(int recordId)
        {
            // guard clause - not found
            IRecommendation recommendation = GetRecommendation(recordId);
            if (recommendation == null)
            {
                return;
            }

            UnitOfWork.Recommendations.Remove(recommendation);
        }

        public virtual void RemoveRecommendation(IRecommendation recommendation)
        {
            // guard clause - invalid input
            if (recommendation == null)
            {
                return;
            }

            RemoveRecommendation(recommendation.RecordId);
        }

        #endregion

    }
}
