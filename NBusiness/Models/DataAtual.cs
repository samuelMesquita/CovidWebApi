using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entidade
{
    public class DataAtual : BaseEntity
    {
        [Column(TypeName = "varchar(30)")]
        public string Data { get; set; }
    }
}
