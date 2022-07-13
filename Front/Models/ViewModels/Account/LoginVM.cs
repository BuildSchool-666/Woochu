using System.ComponentModel.DataAnnotations;

namespace Front.Models.ViewModels.Account
{
    public class LoginVM
    {
        
        public string Phone { get; set; }
        [Required(ErrorMessage ="要填喔")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(8,ErrorMessage = "沒機會顯示")]
        public string Password { get; set; }

    }
}
