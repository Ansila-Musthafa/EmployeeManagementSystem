

using System.ComponentModel.DataAnnotations;

namespace Employee_Mangement_system.Models
{
    public class LoginMvc
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string?Password { get; set; }
    }
}

