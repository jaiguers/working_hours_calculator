using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Person_Services")]
    public class PersonServices
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Start_Date", TypeName = "datetime")]
        public DateTime StarDate { get; set; }

        [Column("End_Date", TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [Column("Id_Services", TypeName = "bigint")]
        public long IdServices { get; set; }

        [Column("Id_Person", TypeName = "bigint")]
        public long IdPerson { get; set; }

        [Column("Week_Number", TypeName = "int")]
        public int WeekNumber { get; set; }

        [Column("Id_User", TypeName = "nvarchar(450)")]
        public string IdUser { get; set; }

        [ForeignKey("IdServices")]
        public virtual Person Person { get; set; }

        [ForeignKey("IdServices")]
        public virtual Services Services { get; set; }
    }
}
