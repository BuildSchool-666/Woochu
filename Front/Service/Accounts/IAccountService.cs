using Front.Models.DTOModels.Account;
using MVCModels.DataModels;

namespace Front.Service.Accounts
{
    public interface IAccountService
    {
        CreateAccountOutputDTO CreateAccount(CreateAccountInputDTO input);
        LoginAccountOutputDTO LoginAccount(LoginAccountInputDTO input);
        void LogoutAccount();
        bool IsExistAccount(string email);

        void SendVerifyMail(string email);
        User FindAccountOrNull(string email);

        User FindAccountOrNull(int userId);

        void VerifyAccount(int userId);

    }
}
