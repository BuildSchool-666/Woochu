using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Front.Service.PublishRoom
{
    public class PublishRoomService : IPublishRoomService
    {
        private readonly WoochuRepository _repo;

        public PublishRoomService(WoochuRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<PublishRoomVM> GetRoomTypeParent()
        {
            return _repo.GetAll<RoomType>().Where(rt => rt.ParentId == null).Select(x => new PublishRoomVM()
            {
                //RoomTypeItem.
                RoomTypeId = x.RoomTypeId,
                RoomTypeName = x.RoomTypeName
            });
        }
        public IEnumerable<PublishRoomVM> GetRoomType(int parentId)
        {
            return _repo.GetAll<RoomType>().Where(rt => rt.ParentId == parentId).Select(x => new PublishRoomVM()
            {
                RoomTypeId = x.RoomTypeId,
                RoomTypeName = x.RoomTypeName
            });
        }
        public void CreateRoom(PublishRoomApiInputDTO input)
        {
            //var entity = new Room()
            //{
            //    //UserId = _repo.GetAll<User>().SingleOrDefault(u => u.Email == userEmail).UserId,
            //    RoomName = input.RoomName,
            //    UserId = 4,
            //    RoomTypeId = input.RoomTypeId,
            //    PrivacyTypeId = input.PrivacyTypeId,
            //    GuestCount = input.GuestCount,
            //    City = input.City,
            //    District = input.District,
            //    Address = input.Address,
            //    ZipCode = input.ZipCode,
            //    UpdateTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
            //    CreateTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
            //    RoomStatus = 1,
            //    Description = input.Description,
            //    BasicPrice = input.BasicPrice,
            //    ServiceCharge = input.ServiceCharge,
            //};

            //_repo.Create<Room>(entity);
            //_repo.SaveChanges();

            //var room = _repo.GetAll<Room>().OrderByDescending(r => r.CreateTime).FirstOrDefault(r => r.UserId == 4);
            //var result = new PublishRoomApiInputDTO()
            //{
            //     RoomId = room.RoomId,
            //     UserId = room.UserId,
            //     RoomTypeId = room.RoomTypeId,
            //};


            //return result;

        }
        //public PublishRoomApiOutputDTO UpdateRoom(PublishRoomApiInputDTO input)
        //{
        //    var target = _repo.GetAll<Room>().FirstOrDefault(x => x.RoomId == input.RoomId);
        //    target.RoomTypeId = input.RoomTypeId;
        //    target.PrivacyTypeId = input.PrivacyTypeId;
        //    target.Address = input.Address;
        //    target.GuestCount = input.GuestCount;
        //    var targetfacility = _repo.GetAll<RoomFacility>().SingleOrDefault(rf => rf.RoomId == input.RoomId && rf.FacilityId == 13);
        //    try
        //    {
        //        _repo.Update(target);
        //        _repo.SaveChanges();
        //        result.IsSuccess = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = ex.Message;
        //    }
        //    return result;
        //}

        public IEnumerable<PublishRoomVM> GetFacility()
        {
            return _repo.GetAll<Facility>().Select(f => new PublishRoomVM()
            {
                FacilityId = f.FacilityId,
                FacilityName = f.FacilityName,
                Icon = f.Icon,
            });
        }
    }
}
