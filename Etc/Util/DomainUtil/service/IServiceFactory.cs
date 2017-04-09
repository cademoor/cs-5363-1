namespace Ttu.Domain
{
    public interface IServiceFactory
    {

        IRecommendationService CreateRecommendationService(IUnitOfWork unitOfWork);
        IUserService CreateUserService(IUnitOfWork unitOfWork);

    }
}
