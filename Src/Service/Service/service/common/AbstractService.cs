using Ttu.Domain;

namespace Ttu.Service
{
    public abstract class AbstractService : AbstractApplicationLogger
    {

        # region Constructors

        protected AbstractService(IUnitOfWork unitOfwork)
        {
            UnitOfWork = unitOfwork;
        }

        # endregion

        # region Properties

        protected ServiceEnvironment ServiceEnvironment { get { return ServiceEnvironment.Singleton; } }
        protected IUnitOfWork UnitOfWork { get; private set; }

        # endregion

    }
}
