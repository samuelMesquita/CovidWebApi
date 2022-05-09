using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entidade
{
    public class DataAtual : BaseEntity
    {
        [Column(TypeName = "Date")]
        public DateTime Data { get; set; }
    }
}
