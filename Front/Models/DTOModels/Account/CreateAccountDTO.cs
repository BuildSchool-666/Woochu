namespace Front.Models.DTOModels.Account
{
    public class CreateAccountInputDTO
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

    }
    public class CreateAccountOutputDTO: BaseOutputDTO
    {
        

    }
}
