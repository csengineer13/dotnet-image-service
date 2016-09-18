using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ImageService.Models;

namespace ImageService.Utilities
{
    public static class ImageHelpers
    {
        public static IHttpActionResult ReturnImage(byte[] image, MediaType mediaType)
        {
            var responseMsg = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(image) };
            responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType.ToString());
            var response = ResponseMessage(responseMsg);
            return response;
        }

        public static byte[] DownloadRemoteImageFile(string uri)
        {
            byte[] content;
            var request = (HttpWebRequest)WebRequest.Create(uri);

            using (var response = request.GetResponse())
            {
                content = ReadAllBytes(response.GetResponseStream());
            }

            return content;
        }

        public static byte[] ReadAllBytes(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}