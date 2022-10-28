using Microsoft.Build.Framework;

namespace Employee_Mangement_system.Models
{
    public class AdminRegistrationMvc
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
