namespace Front.Models.DTOModels.Rooms
{
    public class GetRoomTypeInputDTO
    {
    }
    public class GetRoomTypeOutputDTO : BaseOutputDTO
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
    }
}
