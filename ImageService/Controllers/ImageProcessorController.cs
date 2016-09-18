using System.Drawing;
using System.IO;
using System.Web.Http;
using ImageProcessor;
using ImageService.Models;
using ImageService.Utilities;

namespace ImageService.Controllers
{
    [RoutePrefix("Api/ImageProcessor")]
    public class ImageProcessor : ApiController
    {

        // todo: create class of "ImageXXX"
        // Has single property of byte[] that is the image/file
        // Has methods that apply various transformations...
        // Has method to return image as response message?
        // Should probably also have default starting point as a memory stream as needed for all transforms...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [Route("Scale/")]
        public IHttpActionResult Scale(string imageUrl, int width, int height = 0)
        {
            var imageBytes = ImageHelpers.DownloadRemoteImageFile(imageUrl);
            byte[] image;

            Size size = new Size(width, height);
            using (MemoryStream inStream = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Save(outStream);
                    }
                    image = outStream.ToArray();
                }
            }

            return ImageHelpers.ReturnImage(image, MediaType.JPEG);
        }

    }
}
