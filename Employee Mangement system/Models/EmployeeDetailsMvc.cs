using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Employee_Mangement_system.Models
{
    public class EmployeeDetailsMvc
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "First Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Last Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Key]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Password { get; set; }


        [RegularExpression(@"^\w+(@gmail\.com)$", ErrorMessage = "Enter a Valid Email Id")]
        [Display(Name = "Email Id")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string? EmailId { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Enter Valid Phone no:")]
        
        public double? Mobile { get; set; }

        [Required(ErrorMessage = "Please provide Address")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        public int? Salary { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Designation { get; set; }

        [Display(Name = "Upload Image")]
        public string? UploadImage { get; set; }
    }


}
