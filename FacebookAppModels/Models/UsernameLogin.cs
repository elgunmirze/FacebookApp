using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FacebookApp.Models.Models
{
    [ExcludeFromCodeCoverage]
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