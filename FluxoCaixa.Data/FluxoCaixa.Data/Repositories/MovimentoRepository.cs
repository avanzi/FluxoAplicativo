using FluxoCaixa.Data.Context;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Data.Repositories
{
    public class MovimentoRepository : IMovimentoRepository
    {
        public AppDbContext _context;

        public MovimentoRepository(AppDbContext context)
        {
            _context = context;

        }

        public Movimento Add(Movimento movimento)
        {
            try
            {
                _context.Add(movimento);
                _context.SaveChanges();
                return movimento;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<Movimento> GetAll()
        {
            return _context.Movimentos.ToList();
        }

        public MovimentoDiario GetSaldoDiario(DateTime datebase)
        {
            throw new NotImplementedException();
        }

        public Movimento Update(Movimento movimento)
        {
            try
            {
                _context.Update(movimento);
                _context.SaveChanges();
                return movimento;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
