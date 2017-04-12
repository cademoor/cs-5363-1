using Ttu.Domain;

namespace Ttu.Presentation
{
    public interface IPresenterFactory
    {

        // attributes
        IUnitOfWork UnitOfWork { get; }
        IUser User { get; }
        IOrganization Organization { get; }

        // behavior
        LogOnPresenter CreateLogOnPresenter();
        ManageOrganizationPresenter CreateManageOrganizationPresenter();
        ManageOrganizationUserPresenter CreateManageOrganizationUserPresenter();
        ManageRecommendationPresenter CreateManageRecommendationPresenter();
        ManageUserPresenter CreateManageUserPresenter();
        ManageProjectPresenter CreateManageProjectPresenter();


    }
}
