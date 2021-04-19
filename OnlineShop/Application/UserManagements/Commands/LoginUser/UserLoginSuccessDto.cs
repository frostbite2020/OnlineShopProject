using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserManagements.Commands.LoginUser
{
    public class UserLoginSuccessDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
