using Ecommerce.MessageBus;
using Ecommerce.Service.AuthAPI.Dtos;
using Ecommerce.Service.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Ecommerce.Service.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;
        public AuthAPIController(IAuthService authService, IMessageBus messageBus, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
            _messageBus = messageBus;
            _response = new();
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {

            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                _response.type = errorMessage.Contains("Passwords") ? "password" : "email";
                return BadRequest(_response);
            }
            var topic_name = _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue");
            await _messageBus.PublishMessage(model.Email, topic_name);
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
            {
                var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                _response.type = "password";
                return BadRequest(_response);
            }
            _response.Data = loginResponse;
            return Ok(_response);

        }

        [Authorize]
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest model)
        {
            var responseRefresh = await _authService.Refresh(model);
            if (responseRefresh == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Invalid token";
                return BadRequest(_response);
            }
            _response.Data = responseRefresh;
            return Ok(_response);

        }

        [Authorize]
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);

        }

        [HttpPost("Logout")]
        public IActionResult Logout ()
        {
            return Ok(_response);
        }

        [Authorize]
        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser( [FromForm] UserRequestDto model)
        {
            try
            {
                if (model.Avatar != null)
                {
                    Directory.Delete(@"wwwroot\Avatar\" + model.Email, true);

                    Directory.CreateDirectory(@"wwwroot\Avatar\" + model.Email);

                    string fileName =model.Avatar.FileName + Path.GetExtension(model.Avatar.FileName);

                    string filePath = @"wwwroot\Avatar\" + model.Email + "\\" + fileName;


                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fileStream);
                    }
                    var baseUrl = $"{this.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    model.AvatarUrl = baseUrl + "/Avatar/" + model.Email+ "/"+ fileName; ;
                }
              
                var message = await _authService.EditUser(model);
                if (message == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Data = message;

                return Ok(_response);

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            _response.IsSuccess = false;
            return BadRequest(_response);

        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            try
            {
                await _authService.ChangePassword(model);
                return Ok(_response);
            }
            catch (Exception ex) {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }


        }

        [Authorize]
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _authService.GetUser(id);
                _response.Data = user;
                
                if (user == null)
                {
                    _response.IsSuccess = false;

                    return BadRequest(_response);
                }

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);

            }

        }
    }
}
