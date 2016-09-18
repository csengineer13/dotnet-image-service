using System.Web.Http;
using ImageService.Models;
using ImageService.Utilities;

namespace ImageService.Controllers
{
    [RoutePrefix("Api/Image")]
    public class ImageController : ApiController
    {
        [Route("GetImageByUrl/")]
        public IHttpActionResult GetImageByUrl(string imageUrl)
        {
            var image = ImageHelpers.DownloadRemoteImageFile(imageUrl);
            return ImageHelpers.ReturnImage(image, MediaType.JPEG);
        }



        //[Route("GetImageBy")]
        //public IHttpActionResult GetImageB()
        //{
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    //String filePath = HostingEnvironment.MapPath("~/Images/HT.jpg");
        //    //FileStream fileStream = new FileStream(filePath, FileMode.Open);
        //    //Image image = Image.FromStream(fileStream);
        //    //MemoryStream memoryStream = new MemoryStream();
        //    //image.Save(memoryStream, ImageFormat.Jpeg);
        //    result.Content = new ByteArrayContent(memoryStream.ToArray());
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

        //    return (IHttpActionResult)result;
        //}
    }
}
