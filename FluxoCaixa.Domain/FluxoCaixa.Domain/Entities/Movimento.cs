using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Domain.Entities
{
    public class Movimento : BaseEntity
    {
        [Required(ErrorMessage = "É necessario informar a Data do Movimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataMovimento { get; set; }

        [Required(ErrorMessage = "É necessario informar o Tipo do Movimento")]
        [RegularExpression("[cCDd]")]
        [StringLength(1)]
        public string TipoMovimento { get; set; }

        public string Descricao { get; set; }
        [Required(ErrorMessage = "É necessario informar o valor do Movimento")]
        public Decimal? Valor { get; set; }
    }
}
