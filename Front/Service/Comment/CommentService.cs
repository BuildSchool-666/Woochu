
using Front.Models.DTOModels;
using Front.Models.ViewModels.Comment;
using Front.Service.Comment;
using Microsoft.AspNetCore.Mvc;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Linq;

namespace Front.Service.Comment
{
    public class CommentService : ICommentService
    {
        private readonly WoochuRepository _repo;
        public CommentService(WoochuRepository repo)
        {
            _repo = repo;
        }
        
        public CommentApiOutputDTO CreateComment(CommentApiInputDTO input)
        {
            var result = new CommentApiOutputDTO()
            {
                IsSuccess = false,
            };
            var inputcomment = new MVCModels.DataModels.Comment()
            {
                RoomId = input.RoomId,
                UserId = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email).UserId,
                Content = input.comment,
                CreateTime = (DateTimeOffset.Now - DateTimeOffset.Now.Offset).AddHours(8).DateTime,
                Cleanliness = input.Cleanliness,
                Accuracy = input.Accuracy,
                Communication = input.Communication,
                CheckIn = input.CheckIn,
                Cp = input.CP,
                Location = input.Location,

            };
            try
            {
                _repo.Create(inputcomment);
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

        public CommentApiOutputDTO DeleteComment(CommentApiInputDTO input)
        {
            var result = new CommentApiOutputDTO()
            {
                IsSuccess = false,
            };
            var user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email).UserId;
            var comment = _repo.GetAll<MVCModels.DataModels.Comment>().SingleOrDefault(wl => wl.UserId == user && wl.CommentId == input.CommentId);


            try
            {
                _repo.Delete(comment);
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

        public GetCommentOutputDTO GetComment(GetCommentInputDTO input)
        {
            var result = new GetCommentOutputDTO
            {
                IsSuccess = false,
            };

            if (false)
            {
                result.Message = "some failure msg";

            }

            var user = _repo.GetAll<User>().FirstOrDefault(x => x.Email == input.Email);
            //var hostId = _repo.GetAll<User>().FirstOrDefault(x => x.Email == input.Email)
            var order = _repo.GetAll<MVCModels.DataModels.Order>().Where(x => x.CustomerId == user.UserId);
            //var room = _repo.GetAll<MVCModels.DataModels.Room>().Where(x => x.UserId == order.HostId);

            result.vm = new CommentlistVM
            {
                Comment = order.ToList().Select(o => new CommentVM
                {
                    UserId = user.UserId,
                    RoomId = o.RoomId,
                    RoomTitle = _repo.GetAll<Room>().SingleOrDefault(r => r.RoomId ==  o.RoomId).RoomName,
                    HostName = _repo.GetAll<User>().SingleOrDefault(u => u.UserId == o.HostId).LastName + ", "
                                + _repo.GetAll<User>().SingleOrDefault(u => u.UserId == o.HostId).FirstName,
                    OrderDate = o.OrderDate,
                    CheckInDate = o.CheckInDate,
                    CheckOutDate = o.CheckOutDate,
                    TotalPrice = o.TotalPrice,
                    Email = user.Email,
                }).ToList(),
                

            };

            

            result.IsSuccess = true;
            return result;
        }


        //public GetCommentOutputDTO GetComment(GetCommentInputDTO input)
        //{
        //    var result = new GetCommentOutputDTO
        //    {
        //        IsSuccess = false,
        //    };

        //    if (false)
        //    {
        //        result.Message = "some failure msg";

        //    }

        //    var user = _repo.GetAll<User>().FirstOrDefault(x => x.Email == input.Email);
        //    var order = _repo.GetAll<MVCModels.DataModels.Order>().FirstOrDefault(x => x.CustomerId == user.UserId);
        //    var room = _repo.GetAll<MVCModels.DataModels.Room>().FirstOrDefault(x => x.UserId == order.HostId);




        //    var commnetlist = new GetCommentOutputDTO
        //    {
        //        vm = new CommentVM
        //        {
        //            UserId = user.UserId,
        //            RoomId = room.RoomId,
        //            RoomTitle = room.RoomName,
        //            HostId = order.HostId,
        //            OrderDate = order.OrderDate,
        //            CheckInDate = order.CheckInDate,
        //            CheckOutDate = order.CheckOutDate,
        //            TotalPrice = order.TotalPrice,
        //            Email = user.Email,
        //        }
                
        //};           

        //    result.IsSuccess = true;
        //    return commnetlist;
        //}

        
    }


}
