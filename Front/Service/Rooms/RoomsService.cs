using Front.Models.DTOModels.Rooms;
using Front.Models.ViewModels.Rooms;
using MVCModels.DataModels;
using MVCModels.MyEnum;
using MVCModels.Repositories;
using System;
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

            if (input.Person != 0)
            {
                tmp = tmp.Where(r => r.GuestCount >= input.Person);
            }

            //var aa = tmp.ToList().Select(r => new RoomVM
            //{

            //    BedCount = _repo.GetAll<RoomFacility>()
            //                        .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bed),
            //});
            //var bb = tmp.ToList().Select(r => new RoomVM
            //{

            //    BedCount = _repo.GetAll<RoomFacility>()
            //                        .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bath),
            //});
            result.VM = new RoomlistVM
            {
                City = input.City.ToString(),
                Rooms = tmp.ToList().Select(r =>
                //{
                //    RoomVM rvm = new RoomVM()
                //    {
                //        Title = r.RoomName,
                //        HouseInfo = r.Description,
                //        RentPrice = (int)r.BasicPrice,
                //        Rating = 2.5,
                //    };

                //    rvm.ImgUrl = _repo.GetAll<ImageFile>()
                //                        .FirstOrDefault(img => img.RoomId == r.RoomId).Picture;
                //    rvm.BedCount = _repo.GetAll<RoomFacility>()
                //                        .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bed);

                //    rvm.BathCount = _repo.GetAll<RoomFacility>()
                //                        .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bath);


                //    return rvm;
                //}

                new RoomVM
                {
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

            //foreach( var r in tmp.ToList())
            //{
            //    RoomVM rvm = new RoomVM()
            //    {
            //        Title = r.RoomName,
            //        HouseInfo = r.Description,
            //        RentPrice = (int)r.BasicPrice,
            //        Rating = 1,
            //    };

            //    rvm.ImgUrl = _repo.GetAll<ImageFile>()
            //                        .FirstOrDefault(img => img.RoomId == r.RoomId).Picture;
            //    rvm.BedCount = _repo.GetAll<RoomFacility>()
            //                        .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bed);
            //    rvm.BathCount = _repo.GetAll<RoomFacility>()
            //                        .Count(rf => rf.RoomId == r.RoomId && rf.FacilityId == (int)FacilityID.Bath);


            //    result.VM.Rooms.Add(rvm);
            //};


            result.IsSuccess = true;

            return result;
        }
    }
}
