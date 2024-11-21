using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Service.AuthAPI.Data;
using Ecommerce.Service.AuthAPI.Dtos;
using Ecommerce.Service.AuthAPI.Models;
using Ecommerce.Service.AuthAPI.Service;
using Ecommerce.Service.AuthAPI.Service.IService;
using Ecommernce.AuthAPI.Data.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;

namespace Ecommerce.AuthAPI.Service.Test
{
    public class AuthServiceTest
    {
        private readonly DataContext _context;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<IOptions<JwtOptions>> _jwtOptionsMock;
        private readonly Mock<IJwtTokenGenerator> _jwtTokenGeneratorMock;
        public AuthServiceTest()
        {
            _context = ContextFactory.Create();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            _jwtOptionsMock = new Mock<IOptions<JwtOptions>>();
            _jwtTokenGeneratorMock = new Mock<IJwtTokenGenerator>();
        }

        [Fact]
        public void Login_SuccessResult()
        {
            var authService = new AuthService(_context, _jwtTokenGeneratorMock.Object, _userManagerMock.Object, _roleManagerMock.Object);
            var result = authService.Login(new LoginRequestDto
            {
                Email = "anhdongoc18@gmail.com",
                Password = "Admin@123"
            });

            Assert.NotNull(result);
        }

        [Fact]
        public void Register_Success_Result()
        {
            var authService = new AuthService(_context, _jwtTokenGeneratorMock.Object, _userManagerMock.Object, _roleManagerMock.Object);

            var result = authService.Register(new RegistrationRequestDto
            {
                Email = "anhdongoc18@gmail.com",
                Password = "Admin@123"
            });
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_Role_SuccessResult()
        {
            var authService = new AuthService(_context, _jwtTokenGeneratorMock.Object, _userManagerMock.Object, _roleManagerMock.Object);
            var result = authService.AssignRole("anhdongoc18@gmail.com", "ADMIN");
            Assert.NotNull(result);

        }
    }
}
