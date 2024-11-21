using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Service.AuthAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommernce.AuthAPI.Data.Test
{
    public  class AppDbContextTest
    {
        private readonly DataContext _context;


        public AppDbContextTest()
        {

            _context = ContextFactory.Create();

        }

        [Fact]
        public void Contructor_CreateINMemoryDb_Success()
        {
            Assert.True(_context.Database.EnsureCreated());
        }
    }
}
