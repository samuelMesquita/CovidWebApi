using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entidade
{
    public class DataAtual : BaseEntity
    {
        [Column(TypeName = "datetime")]
        public DateTime Data { get; set; }
    }
}
