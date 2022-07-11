using Front.Models.DTOModels.RoomDetail;
using Front.Models.ViewModels.RoomDetails;
using MVCModels.DataModels;
using MVCModels.MyEnum;
using MVCModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Front.Service.RoomDetail
{
    public class RoomDetailService : IRoomDetailService
    {
        private readonly WoochuRepository _repo;

        public RoomDetailService(WoochuRepository repo)
        {
            _repo = repo;
        }
        public GetRoomsDetailOutputDTO GetRoomsDetail(GetRoomsDetailInputDTO input)
        {
            var result = new GetRoomsDetailOutputDTO()
            {
                IsSuccess = false,
                VM = new RoomDetailVM(),
            };

            if (false)
            {
                result.Message = "some failure msg";
            }

            var vm = _repo.GetAll<Room>().SingleOrDefault(r => r.RoomId == input.RoomId);
            var roomFacilityIdList = _repo.GetAll<RoomFacility>()
                                .Where(rf => rf.RoomId == input.RoomId).Select(rf => rf.FacilityId).ToList();
            //var facility = _repo.GetAll<Facility>()
            //                    .SingleOrDefault(f => f.FacilityId == );
            

            result.VM = new RoomDetailVM()
            {
                Title = vm.RoomName,
                Address = vm.Address,
                RoomInfo = "RoomInfo",
                BrowseCount = vm.BrowseCount,
                BedCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bed).Quantity,
                PersonCount = vm.GuestCount,
                BathCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bath).Quantity,
                ImgUrls = _repo.GetAll<ImageFile>()
                                .Where(img => img.RoomId == input.RoomId).Select(img => img.Picture).ToList(),
                FacilityItem = new List<FacilityIcon>(),
                RentPrice = (int)vm.BasicPrice,
                Description = vm.Description,
                CleanlinessStar = _repo.GetAll<Comment>().SingleOrDefault(c => c.RoomId == input.RoomId).Cleanliness,
                AccuracyStar = _repo.GetAll<Comment>().SingleOrDefault(c => c.RoomId == input.RoomId).Accuracy,
                CommunicationStar = _repo.GetAll<Comment>().SingleOrDefault(c => c.RoomId == input.RoomId).Communication,
                LocationStar = _repo.GetAll<Comment>().SingleOrDefault(c => c.RoomId == input.RoomId).Location,
                CheckInStar = _repo.GetAll<Comment>().SingleOrDefault(c => c.RoomId == input.RoomId).CheckIn,
                ValueStar = _repo.GetAll<Comment>().SingleOrDefault(c => c.RoomId == input.RoomId).Cp,
                RatingStar = _repo.CalStar(input.RoomId),
                CommentCount = _repo.GetAll<Comment>().Count(c => c.RoomId == input.RoomId),
                //CommentName = 
                //CommentContent = 
                HostId = vm.UserId,
                HostName = (_repo.GetAll<User>()
                                .SingleOrDefault(u => u.UserId == vm.UserId).LastName)
                            + " " +
                           (_repo.GetAll<User>()
                                .SingleOrDefault(u => u.UserId == vm.UserId).FirstName),
                JoinTime = vm.CreateTime,
                LastOnlineTime = 200 / 60,
            };

            roomFacilityIdList.ForEach(fId =>
            {
                result.VM.FacilityItem.Add(
                    new FacilityIcon()
                    {
                        FacilityName = _repo.GetAll<Facility>()
                            .SingleOrDefault(ff => ff.FacilityId == fId).FacilityName,
                        FacilityDisplay = _repo.GetAll<Facility>()
                            .SingleOrDefault(ff => ff.FacilityId == fId).Icon,
                    }
                );
            });
            //roomFacility.ForEach(f =>
            //{
            //    if (_repo.GetAll<Facility>()
            //                .SingleOrDefault(ff => ff.FacilityId == f).FacilityId == f)
            //    {
            //        result.VM.FacilityIcon.Add(
            //            _repo.GetAll<Facility>()
            //                .SingleOrDefault(ff => ff.FacilityId == f).Icon.ToString());
            //    }
            //});

            result.IsSuccess = true;

            return result;
        }
    }
}
