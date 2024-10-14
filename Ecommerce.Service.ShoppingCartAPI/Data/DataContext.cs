using Ecommerce.Service.ShoppingCartAPI.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.ShoppingCartAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
