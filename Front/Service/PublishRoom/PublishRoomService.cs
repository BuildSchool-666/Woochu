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
       
        public IEnumerable<RoomTypeVM> GetRoomTypeParent()
        {
            return _repo.GetAll<RoomType>().Where(rt => rt.ParentId == null).Select(x => new RoomTypeVM()
            {
                RoomTypeId = x.RoomTypeId,
                RoomTypeName = x.RoomTypeName
            });
        }
        public IEnumerable<RoomTypeVM> GetRoomType()
        {
            return _repo.GetAll<RoomType>().Where(rt => rt.ParentId != null).Select(x => new RoomTypeVM()
            {
                RoomTypeId = x.RoomTypeId,
                RoomTypeName = x.RoomTypeName
            });
        }
        public PublishRoomApiOutputDTO CreateRoom(PublishRoomApiInputDTO input)
        {
            var result = new PublishRoomApiOutputDTO()
            {
                IsSuccess = true,
                Message = null
            };

            var entity = new Room()
            {
                UserId = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.UserEmail).UserId,
                RoomTypeId = input.RoomTypeId,
                CreateTime = System.DateTime.UtcNow,
                UpdateTime = System.DateTime.UtcNow
            };
            try
            {
                _repo.Create<Room>(entity);
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
        public PublishRoomApiOutputDTO UpdateRoom(PublishRoomApiInputDTO input)
        {
            var target = _repo.GetAll<Room>().FirstOrDefault(x => x.RoomId == input.RoomId);
            target.RoomTypeId = input.RoomTypeId;
            target.PrivacyTypeId = input.PrivacyTypeId;
            target.Address = input.Address;
            target.GuestCount = input.GuestCount;
            var targetfacility = _repo.GetAll<RoomFacility>().SingleOrDefault(rf => rf.RoomId == input.RoomId && rf.FacilityId == 13);
            
            //var targetfacility;
           
            var a = new PublishRoomApiOutputDTO();

            return a;
        }
    }
}
