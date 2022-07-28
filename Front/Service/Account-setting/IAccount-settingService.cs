using Front.Models.DTOModels.Account_setting_DTO;

namespace Front.Service.Account_setting
{
    public interface IAccount_settingService
    {
        PersonalDetailsOutputDTO GetUserData(PersonalDetailsInputDTO input);
        PersonalDetailsOutputDTO UpdateUserData(PersonalDetailsInputDTO input);
        PersonalDetailsOutputDTO UpdateProfilePhoto(PersonalDetailsInputDTO input);

    }
}
