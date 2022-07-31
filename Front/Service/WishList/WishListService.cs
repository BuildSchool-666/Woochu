using Front.Models.DTOModels.WishList;
using MVCModels.Repositories;
using MVCModels.DataModels;
using System.Linq;
using System;

namespace Front.Service.WishList
{
    public class WishListService : IWishListService
    {
        private readonly WoochuRepository _repo;

        public WishListService(WoochuRepository repo)
        {
            _repo = repo;
        }

        public WishListApiOutputDTO CreateWishList(WishListApiInputDTO input)
        {
            var result = new WishListApiOutputDTO()
            {
                IsSuccess = false,
            };
            
            var entity = new MVCModels.DataModels.WishList()
            {
                UserId = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.UserEmail).UserId,
                RoomId = input.RoomId,
                InsertTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
            };

            try
            {
                _repo.Create<MVCModels.DataModels.WishList>(entity);
                _repo.SaveChanges();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public WishListApiOutputDTO DeleteWishList(WishListApiInputDTO input)
        {
            throw new System.NotImplementedException();
        }
    }
}
