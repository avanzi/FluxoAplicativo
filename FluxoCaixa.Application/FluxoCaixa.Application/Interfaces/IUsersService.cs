using FluxoCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Interfaces
{
    public interface IUsersService
    {
        public User GetUser(string userName, string password);
    }
}
