using System.ComponentModel.DataAnnotations;

namespace Front.Models.ViewModels.Account
{
    public class RegisterVM
    {
      
        [Required(ErrorMessage = "必填有用的信箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "必填密碼")]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "需和密碼相同")]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

    }

    public class GoCheckEmailVM
    {

    }
}
