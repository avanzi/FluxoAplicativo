using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace FluxoCaixa.Application.Services
{
    public class UserService : IUsersService
    {
        public  IUserRepository _repositoryUser;

        public UserService(IUserRepository userRepository)
        {
            _repositoryUser= userRepository;
        }

        public User GetUser(string userName, string password)
        {
            return _repositoryUser.GetUser(userName, password);
        }
    }
}
