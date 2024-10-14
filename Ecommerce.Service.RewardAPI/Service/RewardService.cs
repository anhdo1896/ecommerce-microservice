using Ecommerce.Service.RewardAPI.Data;
using Ecommerce.Service.RewardAPI.Message;
using Ecommerce.Service.RewardAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Service.RewardAPI.Service
{
    public class RewardService : IRewardService
    {
        private DbContextOptions<DataContext> _dbOptions;

        public RewardService(DbContextOptions<DataContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task UpdateRewards(RewardsMessage rewardsMessage)
        {
            try
            {
                Rewards rewards = new()
                {
                    OrderId = rewardsMessage.OrderId,
                    RewardsActivity = rewardsMessage.RewardsActivity,
                    UserId = rewardsMessage.UserId,
                    RewardsDate = DateTime.Now
                };
                await using var _db = new DataContext(_dbOptions);
                await _db.Rewards.AddAsync(rewards);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
