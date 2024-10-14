using Ecommerce.Service.RewardAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Service.RewardAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Rewards> Rewards { get; set; }


    }
}
