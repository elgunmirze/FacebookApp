using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FacebookApp.Models.Models
{
    public class UsernameLogin
    {
        [DisplayName("Username")]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}