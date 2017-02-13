using Ttu.Domain;

namespace Ttu.Presentation
{
    public class AbstractPresenter
    {

        # region Constructors

        public AbstractPresenter(IUser user, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            User = user;
        }

        # endregion

        # region Properties

        protected PresentationEnvironment PresentationEnvironment { get { return PresentationEnvironment.Singleton; } }
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IUser User { get; private set; }
        protected IServiceFactory ServiceFactory { get { return PresentationEnvironment.ServiceFactory; } }

        # endregion

        # region Shared Methods

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

        # endregion

    }
}
