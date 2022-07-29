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
               CreateTime = (DateTime)user.CreateTime
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
        
        public PersonalDetailsOutputDTO UpdateProfilePhoto(PersonalDetailsInputDTO input)
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
                user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
                user.PersonalPhoto = input.VM.PersonalPhoto;

                _repo.Update(user);
                _repo.SaveChanges();
                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            

            user = _repo.GetAll<User>().SingleOrDefault(u => u.Email == input.Email);
            result.VM = new PersonalInformationVM()
            {
               PersonalPhoto = user.PersonalPhoto,
               LastName = user.LastName,
               FirstName = user.FirstName,
               CreateTime = (DateTime)user.CreateTime,
               Email = user.Email
               
               
            };
            result.IsSuccess = true;

            return result;
        }

    }


}
