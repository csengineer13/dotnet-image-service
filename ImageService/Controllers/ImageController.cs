using System.Web.Http;
using ImageService.Models;

namespace ImageService.Controllers
{
    [RoutePrefix("Api/Image")]
    public class ImageController : BaseApiController
    {
        [Route("GetImageByUrl/")]
        public IHttpActionResult GetImageByUrl(string imageUrl)
        {
            var image = new ImageModel(imageUrl);
            return ReturnImage(image, MediaType.JPEG);
        }

        // Hosted Locally

        // Hosted with Amazon S3

        // On User's computer

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
