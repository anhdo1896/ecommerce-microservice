using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Service.AuthAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommernce.AuthAPI.Data.Test
{
    public class EFConnectionTest
    {
        private readonly DataContext _context;


        public EFConnectionTest()
        {

            _context = ContextFactory.Create();

        }
        [Fact]
        public async Task Add_Should_Have_Record_When_Insert()
        {

            await _context.ApplicationUsers.AddAsync(new()
            {
                Name = "Test",
                Email = "anhdongoc18@gmail.com",
                NormalizedEmail = "anhdongoc18@gmail.com",
                UserName = "Test",
                PhoneNumber = "0451961806",
                Address = "Magill"
            });

            await _context.SaveChangesAsync();

            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == "anhdongoc18@gmail.com");

            Assert.NotNull(user);

        }
    }
}
