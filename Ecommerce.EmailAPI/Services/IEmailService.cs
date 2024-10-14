using Ecommerce.EmailAPI.Dtos;
using Ecommerce.Service.EmailAPI.Message;

namespace Ecommerce.Service.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);

    }
}
