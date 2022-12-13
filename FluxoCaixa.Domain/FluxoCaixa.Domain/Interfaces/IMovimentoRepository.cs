using FluxoCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Domain.Interfaces
{
    public interface IMovimentoRepository
    {

        IEnumerable<Movimento> GetAll();

        public Movimento Add(Movimento movimento);

        public Movimento Update(Movimento movimento);

        public MovimentoDiario GetSaldoDiario(DateTime datebase);

    }
}
