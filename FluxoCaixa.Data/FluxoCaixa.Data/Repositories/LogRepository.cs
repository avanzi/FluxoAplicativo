using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluxoCaixa.Data.Context;
using System.CodeDom;

namespace FluxoCaixa.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        public AppDbContext _context;


        public LogRepository(AppDbContext context)
        {
            _context = context;
        }

        public Log Add(Log log)
        {
            try
            {
                _context.Add(log);
                _context.SaveChanges();
                return log;
            }
            catch (Exception)
            {

                return null;
            }
            
            
        }

        public IEnumerable<Log> GetAll()
        {
            return _context.Logs.ToList();
        }
    }
}
