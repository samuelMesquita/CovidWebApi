using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entidade
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
