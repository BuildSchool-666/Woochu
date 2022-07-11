namespace Front.Models.DTOModels
{
    public class CreateAccountInputDTO
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

    }
    public class CreateAccountOutputDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
