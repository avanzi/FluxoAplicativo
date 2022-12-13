using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Domain.Entities
{
    public class Log : BaseEntity
    {
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Descricao {get;set;}

        public string Erro { get; set; }

        public string NomeUsuario { get; set; }
        [Required]
        public string BodyText { get; set; }


    }
}
