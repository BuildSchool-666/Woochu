namespace Front.Models.DTOModels.WishList
{
    public class WishListApiInputDTO
    {
        public string UserEmail { get; set; }
        public int RoomId { get; set; }
    }
    public class WishListApiOutputDTO : BaseOutputDTO
    {
        
    }
}
