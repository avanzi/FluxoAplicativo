using FluxoCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Domain.Interfaces
{
    public  interface IUserRepository
    {
        public User GetUser(string userName, string password);
    }
}
