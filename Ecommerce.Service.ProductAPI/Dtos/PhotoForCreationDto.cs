using Ecommerce.Service.ProductAPI.Helpers;

namespace Ecommerce.Service.ProductAPI.Dtos
{
    public class PhotoForCreationDto
    {

        public string Url { get; set; }
        public IList<IFormFile> Files { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public PhotoForCreationDto()
        {
            DateAdded = DateTime.Now;
        }

    
    }
}
