using AI_Agent_WebApp.Models.Entities;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<Review> GetReviewsByAgent(int agentId);
        void CreateReview(Review review);
    }
}
