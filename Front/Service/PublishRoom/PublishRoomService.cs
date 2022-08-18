using Front.Models.DTOModels.PublishRoom;
using Front.Models.ViewModels.PublishRoom;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static Dapper.SqlMapper;

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
        public IEnumerable<PublishRoomVM> GetFacility()
        {
            return _repo.GetAll<Facility>().Select(f => new PublishRoomVM()
            {
                FacilityId = f.FacilityId,
                FacilityName = f.FacilityName,
                Icon = f.Icon,
            });
        }


        public int CreateRoom(PublishRoomApiInputDTO input)
        {
            var entity = new Room()
            {
                UserId = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.userEmail).UserId,
                RoomName = input.currentRoom.RoomName,
                RoomTypeId = input.currentRoom.RoomTypeId,
                PrivacyTypeId = input.currentRoom.PrivacyTypeId,
                GuestCount = input.currentRoom.GuestCount,
                City = input.currentRoom.City,
                District = input.currentRoom.District,
                Address = input.currentRoom.Address,
                ZipCode = input.currentRoom.ZipCode,
                UpdateTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
                CreateTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
                PublishTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
                RoomStatus = 1,
                Description = input.currentRoom.Description,
                BrowseCount = 0,
                BasicPrice = input.currentRoom.BasicPrice,
                ServiceCharge = input.currentRoom.ServiceCharge,
            };

            _repo.Create<Room>(entity);
            _repo.SaveChanges();

            int roomId = _repo.GetAll<Room>().OrderByDescending(r => r.PublishTime).FirstOrDefault(r => r.UserId == entity.UserId).RoomId;

            return roomId;

        }



        public void CreateImage(PublishRoomApiInputDTO input, int roomId)
        {
            for (var i = 1; i <= input.image.roomImgs.Length; i++)
            {
                var entity = new ImageFile()
                {
                    RoomId = roomId,
                    Picture = input.image.roomImgs[i-1],
                    ImageSort = i,
                };

                _repo.Create<ImageFile>(entity);
            }
            _repo.SaveChanges();

        }

        public void CreateFacility(PublishRoomApiInputDTO input, int roomId)
        {
            var bed = new RoomFacility()
            {
                RoomId = roomId,
                FacilityId = 13,
                Quantity = input.currentRoom.Bed,
            };
            var bedRoom = new RoomFacility()
            {
                RoomId = roomId,
                FacilityId = 11,
                Quantity = input.currentRoom.BedRoom,
            };
            var bath = new RoomFacility()

            {
                RoomId = roomId,
                FacilityId = 12,
                Quantity = input.currentRoom.Bath,
            };
            _repo.Create<RoomFacility>(bed);
            _repo.Create<RoomFacility>(bedRoom);
            _repo.Create<RoomFacility>(bath);

            foreach (var f in input.facility.roomFacility)
            {
                var entity = new RoomFacility()
                {
                    RoomId = roomId,
                    FacilityId = f,
                    Quantity = 1,
                };

                _repo.Create<RoomFacility>(entity);
            }

            _repo.SaveChanges();


        }
    }
}
