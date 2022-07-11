using Front.Models.DTOModels;
using MVCModels.DataModels;

namespace Front.Service.Interface
{
    public interface IAccountService
    {
        CreateAccountOutputDTO CreateAccount(CreateAccountInputDTO input);
        //LoginAccountOutputDTO LoginAccount(LoginAccountInputDTO);
        //void LogoutAccount();
        bool IsExistAccount(string email);

        void SendVerifyMail(string email);
        User FindAccountOrNull(string email);

        User FindAccountOrNull(int userId);
        void VerifyAccount(string email);
        void VerifyAccount(int userId);

    }
}
