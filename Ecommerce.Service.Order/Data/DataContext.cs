using Ecommerce.Service.Order.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Order.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
