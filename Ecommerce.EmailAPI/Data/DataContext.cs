using Ecommerce.EmailAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ecommerce.EmailAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<EmailLogger> EmailLoggers { get; set; }


    }
}
