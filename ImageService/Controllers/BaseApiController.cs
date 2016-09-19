using ImageService.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ImageService.Controllers
{
    public abstract class BaseApiController: ApiController
    {
        // Our Model
        protected IHttpActionResult ReturnImage(ImageModel image, MediaType mediaType)
        {
            var responseMsg = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(image.AsByteArray()) };
            responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType.ToString());
            var response = ResponseMessage(responseMsg);
            return response;
        }

        // Byte Array
        protected IHttpActionResult ReturnImage(byte[] image, MediaType mediaType)
        {
            var responseMsg = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(image) };
            responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType.ToString());
            var response = ResponseMessage(responseMsg);
            return response;
        }
    }
}