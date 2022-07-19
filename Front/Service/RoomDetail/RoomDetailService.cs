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

            var room = _repo.GetAll<Room>().SingleOrDefault(r => r.RoomId == input.RoomId);
            var roomStar = _repo.GetAll<Comment>().Where(c => c.RoomId == input.RoomId);
            

            result.VM = new RoomDetailVM()
            {
                RoomId = room.RoomId,
                Title = room.RoomName,
                Address = room.Address,
                RoomInfo = "RoomInfo",
                BrowseCount = (int)room.BrowseCount,
                BedCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bed).Quantity,
                PersonCount = (int)room.GuestCount,
                BathCount = _repo.GetAll<RoomFacility>()
                                .SingleOrDefault(r => r.RoomId == input.RoomId && r.FacilityId == (int)FacilityID.Bath).Quantity,
                ImgUrls = _repo.GetAll<ImageFile>()
                                .Where(img => img.RoomId == input.RoomId).Select(img => img.Picture).ToList(),
                FacilityItem = new List<FacilityIcon>(),
                RentPrice = (int)room.BasicPrice,
                Description = room.Description,
                CleanlinessStar = roomStar.Select(c => c.Cleanliness).Average(),
                AccuracyStar = roomStar.Select(c => c.Accuracy).Average(),
                CommunicationStar = roomStar.Select(c => c.Communication).Average(),
                LocationStar = roomStar.Select(c => c.Location).Average(),
                CheckInStar = roomStar.Select(c => c.CheckIn).Average(),
                ValueStar = roomStar.Select(c => c.Cp).Average(),
                RatingStar = CalStar.CalRoomStar(_repo, input.RoomId),
                CommentCount = _repo.GetAll<Comment>().Count(c => c.RoomId == input.RoomId),
                CommentItem = new List<CommentInformation>(),
                HostId = room.UserId,
                HostName = (_repo.GetAll<User>()
                                .SingleOrDefault(u => u.UserId == room.UserId).LastName)
                            + " " +
                           (_repo.GetAll<User>()
                                .SingleOrDefault(u => u.UserId == room.UserId).FirstName),
                HostPic = "",
                HostRatingStar = 0.0,
                JoinTime = room.CreateTime,
                LastOnlineTime = 200 / 60,
            };

            var roomFacilityIdList = _repo.GetAll<RoomFacility>()
                                .Where(rf => rf.RoomId == input.RoomId).Select(rf => rf.FacilityId).ToList();
            roomFacilityIdList.ForEach(fId =>
            {
                var facilityItem = _repo.GetAll<Facility>()
                                    .SingleOrDefault(ff => ff.FacilityId == fId);
                if (facilityItem != null)
                {
                    result.VM.FacilityItem.Add(
                        new FacilityIcon()
                        {
                            FacilityName = facilityItem.FacilityName,
                            FacilityDisplay = facilityItem.Icon,
                        }
                    );
                }
                
            });
            var roomCommentList = _repo.GetAll<Comment>()       //everyone's comment to the room
                                .Where(c => c.RoomId == input.RoomId).ToList();
            roomCommentList.ForEach(rc =>
            {
                List<double> stars = new List<double> { rc.Cleanliness, rc.Accuracy, rc.Communication, rc.Location, rc.CheckIn, rc.Cp };
                if (stars.Any(s => s != null))
                {
                    var userName = _repo.GetAll<User>().SingleOrDefault(u => u.UserId == rc.UserId);

                    result.VM.CommentItem.Add(
                        new CommentInformation()
                        {
                            CommentName = userName.LastName + userName.FirstName,
                            CommentContent = rc.Content,
                            CommentDate = rc.CreateTime,
                            PersonRatingStar = CalStar.CalPersonStar(rc.Cleanliness, rc.Accuracy, rc.Communication, rc.Location, rc.CheckIn, rc.Cp),
                        }
                    );
                }

            });

            var hostRoomIdList = _repo.GetAll<Room>().Where(c => c.UserId == room.UserId).Select(c => c.RoomId).ToList();
            int hostRoomCount = 0;
            double hostRoomStar = 0;
            hostRoomIdList.ForEach(roomId =>
            {
                double star = CalStar.CalRoomStar(_repo, roomId);
                if (!double.IsNaN(star))
                {
                    hostRoomStar += star;
                    hostRoomCount++;
                }
                
            });
            result.VM.HostRatingStar = hostRoomStar / hostRoomCount;


            result.IsSuccess = true;

            return result;
        }

        //public double CalPersonStar(double CleanlinessStar, double AccuracyStar, double CommunicationStar, double LocationStar, double CheckInStar, double ValueStar)
        //{
        //    double score =
        //        CleanlinessStar
        //        + AccuracyStar
        //        + CommunicationStar
        //        + LocationStar
        //        + CheckInStar
        //        + ValueStar;

        //    score /= 6;
        //    decimal.Round((decimal)score, 1);
        //    return score;
        //}
    }
}
