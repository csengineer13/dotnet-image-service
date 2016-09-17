using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ImageService.Models;

namespace ImageService.Controllers
{
    [RoutePrefix("Api/Image")]
    public class ImageController : ApiController
    {
        ImageModel[] imageModels = new ImageModel[]
 {
            new ImageModel { Id = Guid.NewGuid(), Name = "Tomato Soup"},
            new ImageModel { Id = Guid.NewGuid(), Name = "Yo-yo"},
            new ImageModel { Id = Guid.NewGuid(), Name = "Hammer"}
 };
        [Route("List")]
        public IEnumerable<ImageModel> GetAllImages()
        {
            return imageModels;
        }

        [Route("ByName")]
        public IHttpActionResult GetImage(string name)
        {
            var image = imageModels.FirstOrDefault((p) => p.Name == name);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }
    }
}
