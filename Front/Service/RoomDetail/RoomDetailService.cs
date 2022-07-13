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
            
            result.VM = new RoomDetailVM()
            {
                Title = vm.RoomName,
                Address = vm.Address,
                RoomInfo = "RoomInfo",
                BrowseCount = (int)vm.BrowseCount,
                BedCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bed).Quantity,
                PersonCount = (int)vm.GuestCount,
                BathCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bath).Quantity,
                ImgUrls = _repo.GetAll<ImageFile>()
                                .Where(img => img.RoomId == input.RoomId).Select(img => img.Picture).ToList(),
                FacilityItem = new List<FacilityIcon>(),
                RentPrice = (int)vm.BasicPrice,
                Description = vm.Description,
                CleanlinessStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId).Select(c => c.Cleanliness).Average(),
                AccuracyStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId).Select(c => c.Accuracy).Average(),
                CommunicationStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId).Select(c => c.Communication).Average(),
                LocationStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId).Select(c => c.Location).Average(),
                CheckInStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId).Select(c => c.CheckIn).Average(),
                ValueStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId).Select(c => c.Cp).Average(),
                RatingStar = _repo.CalRoomStar(input.RoomId),
                CommentCount = _repo.GetAll<Comment>().Count(c => c.RoomId == input.RoomId),
                CommentItem = new List<CommentInformation>(),
                HostId = vm.UserId,
                HostName = (_repo.GetAll<User>()
                                .SingleOrDefault(u => u.UserId == vm.UserId).LastName)
                            + " " +
                           (_repo.GetAll<User>()
                                .SingleOrDefault(u => u.UserId == vm.UserId).FirstName),
                JoinTime = vm.CreateTime,
                LastOnlineTime = 200 / 60,
            };

            var roomFacilityIdList = _repo.GetAll<RoomFacility>()
                                .Where(rf => rf.RoomId == input.RoomId).Select(rf => rf.FacilityId).ToList();
            var roomComment = _repo.GetAll<Comment>()       //everyone's comment to the room
                                .Where(c => c.RoomId == input.RoomId).ToList();
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
            //double personStar = roomComment
            roomComment.ForEach(rc =>
            {
                result.VM.CommentItem.Add(
                    new CommentInformation()
                    {
                        CommentName = _repo.GetAll<User>().SingleOrDefault(u => u.UserId == rc.UserId).LastName
                                      +_repo.GetAll<User>().SingleOrDefault(u => u.UserId == rc.UserId).FirstName,
                        CommentContent = rc.Content,
                        CommentDate = rc.CreateTime,
                        PersonRatingStar = _repo.CalPersonStar(rc.Cleanliness,rc.Accuracy,rc.Communication,rc.Location,rc.CheckIn,rc.Cp),
                    }
                );
            });

            result.IsSuccess = true;

            return result;
        }
    }
}
