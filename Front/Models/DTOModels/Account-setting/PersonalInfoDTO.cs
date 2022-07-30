using Front.Models.ViewModels.Account_settings;

namespace Front.Models.DTOModels.Account_setting_DTO
{
    public class PersonalDetailsOutputDTO : BaseOutputDTO
    {
        public PersonalInformationVM VM{ get; set; }
    }

    public class PersonalDetailsInputDTO
    {
        public int UserId { get; set; }
        public PersonalInformationVM VM { get; set; }
        public string Email { get; internal set; }
    }
}
