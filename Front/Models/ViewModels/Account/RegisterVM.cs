using System.ComponentModel.DataAnnotations;

namespace Front.Models.ViewModels.Account
{
    public class RegisterVM
    {
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

    }

    public class GoCheckEmailVM
    {

    }
}
