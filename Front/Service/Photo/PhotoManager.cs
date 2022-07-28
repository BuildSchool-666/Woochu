using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Front.Models.DTOModels.Photo;
using Microsoft.Extensions.Configuration;
using MVCModels;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Configuration;
using MVCModels.DataModels;

namespace Front.Service.Account_setting
{
    public class PhotoManager : IPhotoService
    {
        //public IConfiguration Configuration { get; }
        //private CloudinarySettings _cloudinarySettings;
        //private Cloudinary _cloudinary;
        //private Account Account { get; set; }

        //public PhotoManager(IConfiguration configuration)
        //{

        //    Configuration = configuration;
        //    _cloudinarySettings = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
        //    Account account = new Account(_cloudinarySettings.CloudName,
        //                                  _cloudinarySettings.ApiKey,
        //                                  _cloudinarySettings.ApiSecret);

        //    _cloudinary = new Cloudinary(account);
        //}
        //public User AddPhotoForUser(int userId, PhotoForCreation photoDto)
        //{
        //    var file = photoDto.File;
        //    var uploadResult = new ImageUploadResult();
        //    if (file.Length > 0)
        //    {
        //        using (var stream = file.OpenReadStream())
        //        {
        //            var uploadParams = new ImageUploadParams()
        //            {
        //                File = new FileDescription(file.Name, stream),
        //            };
        //            uploadResult = _cloudinary.Upload(uploadParams);
        //        }
        //    }
        //    photoDto.Url = uploadResult.Url.ToString();
        //    var photo = new ProfilePhoto
        //    {
        //        Url = photoDto.Url,
        //    };
        //    photo.IsMain = true;
        //    return photoDto;

        //}
    }
}
