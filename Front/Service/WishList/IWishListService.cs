using Front.Models.DTOModels.WishList;

namespace Front.Service.WishList
{
    public interface IWishListService
    {
        WishListApiOutputDTO CreateWishList(WishListApiInputDTO input);
        WishListApiOutputDTO DeleteWishList(WishListApiInputDTO input);
    }
}
