using Ecommerce.MessageBus;
using Ecommerce.Service.AuthAPI.Dtos;
using Ecommerce.Service.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : Controller
    {
        private readonly IAuthService _authService;
        //private readonly IMessageBus _messageBus;
        private readonly IRabbitMQBasicMessageSender _messageBus;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;
        public AuthAPIController(IAuthService authService, IRabbitMQBasicMessageSender messageBus, IConfiguration configuration)
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
                return BadRequest(_response);
            }
            var topic_name = _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue");
            //await _messageBus.PublishMessage(model.Email, topic_name);
            _messageBus.SendMessage(model.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
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
                return BadRequest(_response);
            }
            _response.Data = loginResponse;
            return Ok(_response);

        }

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

    }
}
