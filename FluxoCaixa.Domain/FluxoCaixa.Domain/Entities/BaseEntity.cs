using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FluxoCaixa.Domain.Entities
{
    public abstract class BaseEntity
    {
       [Key]
       public virtual Guid id { get; set; } = new Guid();

      

    }
}
