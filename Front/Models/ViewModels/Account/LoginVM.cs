using System.ComponentModel.DataAnnotations;

namespace Front.Models.ViewModels.Account
{
    public class LoginVM
    {
        
        [Required(ErrorMessage ="要填喔")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "要填喔")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
