using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Service.AuthAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommernce.AuthAPI.Data.Test
{
    public class ContextFactory
    {
        public static DataContext Create()
        {
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new DataContext(options);

            return context;
        }


    }
}
