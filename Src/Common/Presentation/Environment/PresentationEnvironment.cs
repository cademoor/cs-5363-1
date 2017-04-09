using Ttu.Domain;

namespace Ttu.Presentation
{
    public class PresentationEnvironment
    {

        public static PresentationEnvironment Singleton = new PresentationEnvironment();

        #region Constructors

        private PresentationEnvironment()
        {
            Map = new ThreadSafeMap<string, IPresenterFactory>();
            ServiceFactory = NullServiceFactory.Singleton;
        }

        #endregion

        #region Properties

        public IServiceFactory ServiceFactory { get; private set; }

        private ThreadSafeMap<string, IPresenterFactory> Map { get; set; }

        #endregion

        #region Public Methods

        public void MapPresenterFactory(string sessionId, IPresenterFactory presenterFactory)
        {
            Map[sessionId] = presenterFactory;
        }

        public void Release(IUnitOfWork unitOfWork)
        {
            // guard clause - invalid state
            if (string.IsNullOrEmpty(unitOfWork?.SessionId))
            {
                return;
            }

            Map.Remove(unitOfWork.SessionId);
        }

        public void SetServiceFactory(IServiceFactory serviceFactory)
        {
            ServiceFactory = serviceFactory ?? NullServiceFactory.Singleton;
        }

        public IPresenterFactory ValidatePresenterFactory(string sessionId)
        {
            // guard clause - session does not exist
            IPresenterFactory presenterFactory = Map[sessionId];
            if (presenterFactory == null)
            {
                throw new BusinessException("Invalid session id.");
            }

            return presenterFactory;
        }

        #endregion

    }
}
