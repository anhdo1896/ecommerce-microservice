using Ecommerce.Service.RewardAPI.Message;

namespace Ecommerce.Service.RewardAPI.Service
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}
