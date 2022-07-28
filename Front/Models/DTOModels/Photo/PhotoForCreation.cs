using Microsoft.AspNetCore.Http;
using System;

namespace Front.Models.DTOModels.Photo
{
    public class PhotoForCreation : BaseOutputDTO
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public string PublicId { get; set; }

        public PhotoForCreation()
        {
            DateAdded = DateTime.UtcNow;
        }
    }
}
