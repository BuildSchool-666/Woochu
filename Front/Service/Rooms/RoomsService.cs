using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using MVCModels.DataModels;
using MVCModels.MyEnum;
using MVCModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Front.Service.Rooms
{
    public class RoomsService : IRoomsService
    {
        private readonly WoochuRepository _repo;

        public RoomsService(WoochuRepository repo)
        {
            _repo = repo;
        }
        public List<GetFacilityOutputDTO> GetFacility()
        {
            var facilitys = _repo.GetAll<Facility>().ToList();
            var result = new List<GetFacilityOutputDTO>();
            facilitys.ForEach(f =>
            {
                var facility = new GetFacilityOutputDTO { 
                    FacilityId = f.FacilityId, 
                    FacilityName = f.FacilityName
                };
                result.Add(facility);
            });
            return result;
        }
        public List<GetRoomTypeOutputDTO> GetRoomType()
        {
            var roomTypes = _repo.GetAll<RoomType>().Where(rt => rt.ParentId == null).ToList();
            var result = new List<GetRoomTypeOutputDTO>();
            roomTypes.ForEach(rt =>
            {
                var roomType = new GetRoomTypeOutputDTO
                {
                    RoomTypeId = rt.RoomTypeId,
                    RoomTypeName = rt.RoomTypeName
                };
                result.Add(roomType);
            });
            return result;
        }
        public GetRoomsCardOutputDTO GetRoomsCard(GetRoomsCardInputDTO input)
        {
            var result = new GetRoomsCardOutputDTO
            {
                IsSuccess = false,
                //VM = new RoomlistVM(),
            };

            if (false)
            {
                result.Message = "some failure msg";
            }

            var tmp = _repo.GetAll<Room>();

            if (input.City != 0)
            {
                tmp = tmp.Where(r => r.City == input.City.ToString());
            }

            if (input.CheckinTime != null && input.CheckoutTime != null)
            {
                //tmp = tmp.Where(r => r.City == input.City.ToString());

                //選取日期不能跟RoomEvent日期有交集
            }

            result.VM = new RoomlistVM
            {
                City = input.City.ToString(),
                Rooms = tmp.ToList().Select(r =>
                    new RoomVM
                    {
                        RoomId = r.RoomId,
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
                        RoomTypeId = _repo.GetAll<RoomType>().SingleOrDefault(rt => rt.RoomTypeId == r.RoomTypeId).RoomTypeId,
                        FacilityItem = 
                            _repo.GetAll<RoomFacility>().Where(rf => rf.RoomId == r.RoomId).ToList()
                            .Select (rf =>
                                new FacilityIcon
                                {
                                    FacilityId = rf.FacilityId,
                                    FacilityName = _repo.GetAll<Facility>().SingleOrDefault(f => f.FacilityId == rf.FacilityId).FacilityName,
                                }
                            ).ToList(),
                    }
                ).ToList(),
            };
            //foreach (var room in result.VM.Rooms)
            //{
            //    result.VM.Rooms.ToList().Select(r => )
            //}

            result.IsSuccess = true;

            return result;
        }
    }
}
