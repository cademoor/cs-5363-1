using Ttu.Domain;
using Ttu.Presentation.Presenter;

namespace Ttu.Presentation
{
    public interface IPresenterFactory
    {

        // attributes
        IUnitOfWork UnitOfWork { get; }
        IUser User { get; }

        // behavior
        LogOnPresenter CreateLogOnPresenter();
        ManageOrganizationPresenter CreateManageOrganizationPresenter();
        ManageOrganizationUserPresenter CreateManageOrganizationUserPresenter();
        ManageRecommendationPresenter CreateManageRecommendationPresenter();
        ManageUserPresenter CreateManageUserPresenter();
        ManageProjectPresenter CreateManageProjectPresenter();
        ProjectPresenter CreateProjectPresenter();
        ProjectApplicationPresenter CreateProjectApplicationPresenter();
    }
}
