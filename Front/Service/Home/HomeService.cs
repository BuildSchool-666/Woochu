using Front.Models.DTOModels.Home;
using Front.Models.ViewModels.Home;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System;
using System.Linq;

namespace Front.Service.Home
{
    public class HomeService : IHomeService
    {
        private readonly WoochuRepository _repo;

        public HomeService(WoochuRepository repo)
        {
            _repo = repo;
        }
        private void CreateData()
        
        {
            var entity = new Room
            {
                RoomName = "宜蘭1",
                UserId = 1,
                RoomTypeId = 1,
                PrivacyTypeId = 1,
                GuestCount = 4,
                City = "宜蘭",
                District = "東區",
                Address = "五福路",
                ZipCode = "300",
                Longitude = 123,
                Latitude = 13,
                UpdateTime = new DateTime(2022, 7, 9, 12, 12, 12),
                CreateTime = new DateTime(2022, 7, 9, 12, 12, 12),
                PublishTime = new DateTime(2022, 7, 9, 12, 12, 12),
                RoomStatus = 1,
                Description = "abc",
                BrowseCount = 1,
                Discount = 0,
                BasicPrice = 100,
                ServiceCharge = 50,
            };
            //var entity2 = new Room
            //{
            //    RoomName = "宜蘭1",
            //    UserId = 1,
            //    RoomTypeId = 1,
            //    PrivacyTypeId = 1,
            //    GuestCount = 4,
            //    City = "宜蘭",
            //    District = "東區",
            //    Address = "五福路",
            //    ZipCode = "300",
            //    Longitude = 123,
            //    Latitude = 123,
            //    UpdateTime = new DateTime(2022, 7, 9, 12, 12, 12),
            //    CreateTime = new DateTime(2022, 7, 9, 12, 12, 12),
            //    PublishTime = new DateTime(2022, 7, 9, 12, 12, 12),
            //    RoomStatus = 1,
            //    Description = "abc",
            //    BrowseCount = 1,
            //    Discount = 0,
            //    BasicPrice = 100,
            //    ServiceCharge = 50,
            //};
            _repo.Create(entity);
            _repo.SaveChanges();
        }
        public GetIndexDataOutputDTO GetIndexData()
        {
            //this.CreateData();

            var result = new GetIndexDataOutputDTO
            {
                IsSuccess = false,
                //Message = null,
                VM = new IndexVM(),
            };

            if(false){
                result.Message = "some failure msg";
            }

            result.VM = new IndexVM()
            {
                CityCards = _repo.GetAll<Room>()
                    .AsEnumerable()
                    .GroupBy(r => r.City)
                    .Select(g => new CityCard
                    {
                        CityName = g.Key,
                        Price = (int)g.Min(r => r.BasicPrice),
                        ImgUrl = _repo.GetAll<ImageFile>()
                                    .FirstOrDefault(img => img.RoomId == g.FirstOrDefault().RoomId)
                                    .Picture,
                    }).ToList(),
            };

            //var citys2 = _repo.GetAll<Room>()
            //    .GroupBy(r => r.City)
            //    .Select(g => new 
            //    {
            //        CityName = g.Key,
            //        Price = (int)g.Min(r => r.BasicPrice),
            //        RoomId = g,
            //    }).ToList();


            //result.VM.CityCards = 
            //    citys
            //    .Select(c => new CityCard
            //    {
            //        CityName = c.CityName,
            //        Price = c.Price,
            //        ImgUrl = _repo.GetAll<ImageFile>()
            //            .FirstOrDefault(img => img.RoomId == c.RoomId)
            //            .Picture
            //    }).ToList();

            //foreach (var city in citys)
            //{

            //    city.ImgUrl = _repo.GetAll<ImageFile>()
            //            .FirstOrDefault(img => img.RoomId == city.FirstOrDefault()?.RoomId)
            //            ?.Picture;
            //}


            result.IsSuccess = true;
            return result;
        }

    }
}
