using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserManagements.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<UserProperty>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserProperty>
    {
        private readonly IUserManagement _services;

        public RegisterUserCommandHandler(IUserManagement services)
        {
            _services = services;
        }
        public async Task<UserProperty> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var model = new UserProperty();
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            model.Username = request.Username;
            model.Email = request.Email;

            var user = await _services.Create(model, request.Password, cancellationToken);

            return user;
        }
    }
}
