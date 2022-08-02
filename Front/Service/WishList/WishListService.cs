using Front.Models.DTOModels.WishList;
using MVCModels.Repositories;
using MVCModels.DataModels;
using System.Linq;
using System;
using Front.Models.DTOModels.RoomDetail;
using Front.Models.ViewModels.Rooms;
using MVCModels.MyEnum;

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

        //public WishListApiOutputDTO DeleteWishList(WishListApiInputDTO input)
        //{
        //    var result = new WishListApiOutputDTO()
        //    {
        //        IsSuccess = false,
        //    };
        //    var target = _repo.GetAll<Pokemon>().FirstOrDefault(x => x.Id == query.Id);

        //    _repository.Delete(target);
        //    _repository.Save();
        //    try
        //    {
        //        _repo.Delete<MVCModels.DataModels.WishList>(target);
        //        _repo.SaveChanges();
        //        result.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = ex.Message;
        //    }

        //    return result;

        //}

        public WishListApiOutputDTO DeleteWishList(WishListApiInputDTO input)
        {
            var result = new WishListApiOutputDTO()
            {
                IsSuccess = false,
            };
            var user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.UserEmail).UserId;

            var wishList = _repo.GetAll<MVCModels.DataModels.WishList>().SingleOrDefault(wl => wl.UserId == user && wl.RoomId == input.RoomId);
            

            try
            {
                _repo.Delete<MVCModels.DataModels.WishList>(wishList);
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

        public GetWishListOutputDTO GetWishList(GetWishListInputDTO input)
        {
            var result = new GetWishListOutputDTO
            {
                IsSuccess = false,
            };
            if (false)
            {
                result.Message = "some failure msg";
            }
            var userId = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.UserEmail).UserId;


            var wish = _repo.GetAll<MVCModels.DataModels.WishList>().Where(w => w.UserId == userId).Select(w => w.RoomId).ToList();
            var wishlist = _repo.GetAll<Room>().Where(r => wish.Contains(r.RoomId)).ToList();

            result.VM = new RoomlistVM
            {
                WishList = _repo.GetAll<MVCModels.DataModels.WishList>().Where(wl => wl.UserId == userId).Select(wl => wl.RoomId).ToList(),
                Rooms = wishlist.Select(r =>
                new RoomVM
                {
                    roomId = r.RoomId,
                    Title = r.RoomName,
                    ImgUrl = _repo.GetAll<ImageFile>()
                                    .FirstOrDefault(img => img.RoomId == r.RoomId).Picture,
                    HouseInfo = r.Description,
                    BedCount = _repo.GetAll<RoomFacility>()
                                    .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bed),
                    BathCount = _repo.GetAll<RoomFacility>()
                                    .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bath),
                    RentPrice = (int)r.BasicPrice,
                    Rating = CalStar.CalRoomStar(_repo, r.RoomId),

                }

                ).ToList(),
            };

            result.IsSuccess = true;

                return result;
            }
    }
}
