using Front.Models.DTOModels.Order;
using Front.Models.DTOModels.RoomDetail;

namespace Front.Service.Order
{
    public interface IOrderService
    {
        GetOrderOutputDTO GetOrderData(GetorderDetailInputDTO input);

    }
}
