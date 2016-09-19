using System.Drawing;
using System.IO;
using System.Web.Http;
using ImageProcessor;
using ImageService.Models;

namespace ImageService.Controllers
{
    [RoutePrefix("Api/ImageProcessor")]
    public class ImageProcessor : BaseApiController
    {

        // todo: 
        // Should probably also have default starting point as a memory stream as needed for all transforms...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [Route("Resize/")]
        public IHttpActionResult Resize(string imageUrl, int width, int height = 0)
        {
            var image = new ImageModel(imageUrl);
            image.Resize(width, height);
            return ReturnImage(image, MediaType.JPEG);
        }

    }
}
