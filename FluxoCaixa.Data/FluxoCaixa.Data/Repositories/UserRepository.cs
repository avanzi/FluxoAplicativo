using FluxoCaixa.Data.Context;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = FluxoCaixa.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        public AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public User GetUser(string userName, string password)
        {
            try
            {
                var retorno = _context.Users.ToList();



                return retorno.Where(e => e.Name == userName && e.Password == password).FirstOrDefault();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
