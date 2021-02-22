using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Services")]
    public class Services
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Names", TypeName = "varchar(50)")]
        public string Names { get; set; }

        [Column("Identification", TypeName = "varchar(50)")]
        public string Identification { get; set; }
    }
}
