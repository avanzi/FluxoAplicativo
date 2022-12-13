using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Services
{
    public class MovimentoService : IMovimentosService
    {
        public IMovimentoRepository _repositoryMovimento;

        public MovimentoService(IMovimentoRepository repositoryMovimento)
        {
            _repositoryMovimento = repositoryMovimento;
        }

        public Movimento Add(Movimento movimento)
        {
            _repositoryMovimento.Add(movimento);
            return movimento;
        }

        public MovimentoDiario GetSaldoDiario(DateTime database)
        {
            var lista = _repositoryMovimento.GetAll().Where(e=> e.DataMovimento.ToShortDateString() == database.ToShortDateString());
            var movd = new MovimentoDiario();
            movd.Data = database;
            movd.Movimentos = lista.ToList();
            movd.Saldo = 0;
            foreach (var item in lista) { 
            
                movd.Saldo = movd.Saldo + (item.TipoMovimento == "C" ? item.Valor : (item.Valor * -1));

            }

            return movd;

        }

        public Movimento Update(Movimento movimento)
        {
            _repositoryMovimento.Update(movimento);
            return movimento;
        }
    }
}
