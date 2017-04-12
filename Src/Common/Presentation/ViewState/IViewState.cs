using Ttu.Domain;

namespace Ttu.Presentation
{
    public interface IViewState
    {

        IUnitOfWork UnitOfWork { get; }
        IUser User { get; }
        IOrganization Organization { get; }

    }
}
