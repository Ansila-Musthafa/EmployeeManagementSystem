using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Mangement_system.Models
{
    public class Designationmvc
    {
        public int Id { get; set; } = 0;
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Designations { get; set; }

    }
}
