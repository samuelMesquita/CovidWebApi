using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entidade
{
    public class Covid : BaseEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Pais { get; set; }
        [Column(TypeName = "int(12)")]
        public int Casos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCasos { get; set; }
    }
}
