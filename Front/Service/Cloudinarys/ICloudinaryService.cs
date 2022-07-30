using Front.Models.DTOModels.Cloudinary;
using System.Threading.Tasks;

namespace Front.Service.Cloudinarys
{
    public interface ICloudinaryService
    {
        Task<UploadImgOutputDTO> UploadAsync(UploadImgInputDTO input);
    }
}
