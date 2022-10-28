using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee_Mangement_system.Models
{
    public class AdminVerificationMvc
    {

        public string? Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        //public string? VerificationToken { get; set; }

        //public DateTime? VerifiedAt { get; set; }
    }
}
