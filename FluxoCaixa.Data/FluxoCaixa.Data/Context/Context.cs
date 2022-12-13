using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain;
using FluxoCaixa.Domain.Entities;
using Pomelo.EntityFrameworkCore.MySql;
using System.Net;
using User = FluxoCaixa.Domain.Entities.User;

namespace FluxoCaixa.Data.Context
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) => Database.EnsureCreated();

       
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<Log> Logs { get; set; }

        public DbSet<User> Users { get; set; }

       

    }
}
