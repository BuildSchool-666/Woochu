namespace Front.Models.DTOModels.Rooms
{
    public class GetFacilityInputDTO
    {
    }
    public class GetFacilityOutputDTO : BaseOutputDTO
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string Icon { get; set; }
    }
}
