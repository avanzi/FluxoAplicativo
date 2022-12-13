using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Domain.Entities
{
    public class MovimentoDiario  
    {
    
        public DateTime Data { get; set; }
        
        public Decimal? Saldo { get; set; }
        public List<Movimento> Movimentos { get; set; }
    }
}
