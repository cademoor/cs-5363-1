using Ttu.Domain;

namespace Ttu.Presentation
{
    public class AbstractPresenter
    {

        #region Constructors

        public AbstractPresenter(IViewState viewState)
        {
            ViewState = viewState;
        }

        #endregion

        #region Properties

        protected PresentationEnvironment PresentationEnvironment { get { return PresentationEnvironment.Singleton; } }
        protected IUnitOfWork UnitOfWork { get { return ViewState.UnitOfWork; } }
        protected IUser User { get { return ViewState.User; } }
        protected IServiceFactory ServiceFactory { get { return PresentationEnvironment.ServiceFactory; } }

        private IViewState ViewState { get; set; }

        #endregion

        #region Shared Methods - Common

        protected void ValidateValue(string fieldName, string value, int minLength, int maxLength, InputType inputType)
        {
            // guard clause - no validation error
            string errorValue = new InputValidationBuilder().ValidateValue(fieldName, value, minLength, maxLength, inputType);
            if (string.IsNullOrEmpty(errorValue))
            {
                return;
            }

            throw new BusinessException(errorValue);
        }

        #endregion

        #region Shared Methods - Persistence

        protected void Commit()
        {
            UnitOfWork.Commit();
        }

        protected void Reset()
        {
            UnitOfWork.Reset();
        }

        #endregion

        #region Shared Methods - Service

        protected IContactService CreateContactService()
        {
            return ServiceFactory.CreateContactService(UnitOfWork);
        }

        protected IOrganizationService CreateOrganizationService()
        {
            return ServiceFactory.CreateOrganizationService(UnitOfWork);
        }

        protected IVolunteerProfileReviewService CreateVolunteerProfileReviewService()
        {
            return ServiceFactory.CreateVolunteerProfileReviewService(UnitOfWork);
        }

        protected IVolunteerProfileService CreateVolunteerProfileService()
        {
            return ServiceFactory.CreateVolunteerProfileService(UnitOfWork);
        }

        protected IUserService CreateUserService()
        {
            return ServiceFactory.CreateUserService(UnitOfWork);
        }

        #endregion

    }
}
