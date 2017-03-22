﻿namespace Ttu.Domain
{
    public interface IRecommendationService
    {

        void AddRecommendation(IRecommendation recommendation);

        IRecommendation GetRecommendation(int recordId);
        IRecommendation[] GetRecommendations();
        IRecommendation[] GetRecommendations(IUser user);

        void RemoveRecommendation(int recordId);
        void RemoveRecommendation(IRecommendation recommendation);

    }
}
