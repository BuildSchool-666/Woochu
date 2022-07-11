using Front.Helpers;
using Front.Models.DTOModels;
using Front.Service.Interface;
using Microsoft.AspNetCore.Http;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Front.Service
{
    public class AccountService : IAccountService
    {
        private readonly WoochuRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(WoochuRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public CreateAccountOutputDTO CreateAccount(CreateAccountInputDTO input)
        {
            var result = new CreateAccountOutputDTO()
            {
                IsSuccess = false,
                //Message = null

            };
            if(IsExistAccount(input.Email))
            {
                result.Message = "Email已存在";
                return result;
            }
            if (input.Password != input.PasswordConfirm)
            {
                result.Message = "密碼不相符";
                return result;
            }
            var entity = new User
            {
                Email = input.Email,
                Password = Encryption.SHA256(input.Password),
                CreateTime = System.DateTime.UtcNow,
            };

            _repo.Create(entity);
            _repo.SaveChanges();

            this.SendVerifyMail(input.Email);
            result.IsSuccess= true;
            return result;
        }

        public void SendVerifyMail(string email)
        {
            var UserId = FindAccountOrNull(email)?.UserId;
            string body = $@"
                <h3>點擊
                    <a href='https://{_httpContextAccessor.HttpContext.Request.Host.Value}/Account/Verify?VIP_NO={UserId}' target='_blank'>鏈接</a>
            已啓用賬戶
                </h3>
            ";
            MailHelper.SendMail(
                new List<string> { email },
                "Woochu會員注冊驗證",
                body
            );
        }

        public bool IsExistAccount(string email)
        {
            return _repo.GetAll<User>().Any(m => m.Email == email);
        }
        public User FindAccountOrNull(string email)
        {
            return _repo.GetAll<User>().FirstOrDefault(m => m.Email == email);
        }

        public User FindAccountOrNull(int userId)
        {
            return _repo.GetAll<User>().FirstOrDefault(m => m.UserId == userId);
        }

        public void VerifyAccount(int userId)
        {
            var user = FindAccountOrNull(userId);
            if(!user.EmailVerify)
            {
                user.EmailVerify = true;
                user.CreateTime = DateTime.UtcNow;

                _repo.Update(user);
                _repo.SaveChanges();
            }
        }

        public void VerifyAccount(string email)
        {
            throw new NotImplementedException();
        }
    }
}
