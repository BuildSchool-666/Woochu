using Front.Models.DTOModels.Account_setting_DTO;
using MVCModels.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Front.Models.ViewModels.Account_settings;
using MVCModels.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System;
using Front.Models.DTOModels.RoomDetail;
using Front.Models.DTOModels.Account_setting;
using Front.Models.ViewModels.Rooms;

namespace Front.Service.Account_setting
{

    public class Account_settingService : IAccount_settingService
    {
        private readonly WoochuRepository _repo;

        public Account_settingService(WoochuRepository repo)
        {
            _repo = repo;
        }
        public PersonalDetailsOutputDTO GetUserData(PersonalDetailsInputDTO input)
        {
            var result = new PersonalDetailsOutputDTO
            {
                IsSuccess = false,
                Message = null
            };

            if (false)
            {
                result.Message = "some failure msg";
            }

            var user = _repo.GetAll<User>().SingleOrDefault(r => r.Email == input.Email);
            

            result.VM = new PersonalInformationVM()
            {
               FirstName = user.FirstName,
               LastName = user.LastName,
               Email = user.Email,
               Gender = user.Gender,
               PersonalPhoto = user.PersonalPhoto,
               CreateTime = (DateTime)user.CreateTime,
               Dob = user.Dob,
               About = user.About,
            };
            
            result.IsSuccess = true;

            return result;
        }
        public PersonalDetailsOutputDTO UpdateUserData(PersonalDetailsInputDTO input)
        {
            var result = new PersonalDetailsOutputDTO
            {
                IsSuccess = false,
                Message = null
            };

            if (false)
            {
                result.Message = "some failure msg";
            }

            User user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
            if (input.VM.FirstName !=null && input.VM.LastName != null)
            {
                
                user.FirstName = input.VM.FirstName;
                user.LastName = input.VM.LastName;
                    //Gender = input.VM.Gender,
            }
            if(input.VM.Gender != null)
            {
                user.Gender = input.VM.Gender;
            }
            if(input.Email != null)
            {
                user.Email = input.Email;
            }
            if(input.VM.Dob != null)
            {
                user.Dob = input.VM.Dob;
            }

            //var member = _repo.GetAll<User>().SingleOrDefault(r => r.UserId == input.UserId);
            //var entity = new User
            //{ 
            //    FirstName = input.VM.FirstName,
            //    LastName = input.VM.LastName,
            //    Gender = input.VM.Gender,
            //};

            _repo.Update(user);
            _repo.SaveChanges();
            user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
            result.VM = new PersonalInformationVM()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                CreateTime = (DateTime)user.CreateTime
            };

            result.IsSuccess = true;

            return result;
        }
        
        public PersonalDetailsOutputDTO UpdateProfile(PersonalDetailsInputDTO input)
        {
            var result = new PersonalDetailsOutputDTO
            {
                IsSuccess = false,
                Message = null
            };

            if (false)
            {
                result.Message = "some failure msg";
            }

            User user = new User();
            try
            {
                if(input.VM.PersonalPhoto != null)
                {
                    user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
                    user.PersonalPhoto = input.VM.PersonalPhoto;
                }
                if(input.VM.About != null)
                {
                    user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
                    user.About = input.VM.About;
                }
                

                _repo.Update(user);
                _repo.SaveChanges();
                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


            user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
            result.VM = new PersonalInformationVM()
            {
               PersonalPhoto = user.PersonalPhoto,
               LastName = user.LastName,
               FirstName = user.FirstName,
               CreateTime = (DateTime)user.CreateTime,
               Email = user.Email,
               About = user.About
               
               
            };
            result.IsSuccess = true;

            return result;
        }

        public GetMyRoomListOutputDTO GetMyRoom(string email)
        {
            var result = new GetMyRoomListOutputDTO
            { 
                IsSuccess = false,
            };
            if (false)
            {
                result.Message = "some failure msg";
            }
            var hostId = _repo.GetAll<User>().SingleOrDefault(r => r.Email == email).UserId;
            var Room = _repo.GetAll<Room>().Where(r => r.UserId == hostId && r.BasicPrice != null).ToList();
            result.VM = Room.Select(r =>
                new RoomVM
                {
                    Title = r.RoomName,
                    HouseInfo = r.Description,
                    ImgUrl = _repo.GetAll<ImageFile>().FirstOrDefault(img => img.RoomId == r.RoomId).Picture,
                    Rating = CalStar.CalRoomStar(_repo, r.RoomId),
                }
            ).ToList();

            result.IsSuccess = true;

            return result;
        }
    
    }


}
