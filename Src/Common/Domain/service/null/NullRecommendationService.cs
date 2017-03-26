namespace Ttu.Domain
{
    public class NullRecommendationService : IRecommendationService
    {

        public static IRecommendationService Singleton = new NullRecommendationService();

        #region Constructors

        protected NullRecommendationService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddRecommendation(IRecommendation recommendation)
        {
            // do nothing
        }

        public virtual IRecommendation GetRecommendation(int recordId)
        {
            return null;
        }

        public virtual IRecommendation[] GetRecommendations()
        {
            return new IRecommendation[0];
        }

        public virtual IRecommendation[] GetRecommendations(IUser user)
        {
            return new IRecommendation[0];
        }

        public virtual void RemoveRecommendation(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveRecommendation(IRecommendation recommendation)
        {
            // do nothing
        }

        #endregion

    }
}
