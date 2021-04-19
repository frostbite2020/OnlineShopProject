using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserManagement
    {
        Task<UserProperty> Authenticate(string username, string password);
        Task<UserProperty> Create(UserProperty user, string password, CancellationToken cancellationToken);   
    }
}
