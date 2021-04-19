using Application.UserManagements.Commands.LoginUser;
using Application.UserManagements.Commands.RegisterUser;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("user-management")]
    public class UserManagementController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<UserProperty> Register(RegisterUserCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("login")]
        public async Task<UserLoginSuccessDto> Login(LoginUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
