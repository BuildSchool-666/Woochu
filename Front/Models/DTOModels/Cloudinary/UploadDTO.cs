using Microsoft.AspNetCore.Http;

namespace Front.Models.DTOModels.Cloudinary
{
    public class UploadImgInputDTO
    {
        public IFormFile File { get; set; }
        public string Path { get; set; }
    }

    public class UploadImgOutputDTO : BaseOutputDTO
    {
        public string Url { get; set; }
    }
}
