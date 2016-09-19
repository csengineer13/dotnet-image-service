using ImageProcessor;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImageService.Models
{
    public class ImageModel
    {
        public ImageModel(string url)
        {
            this.Content = DownloadRemoteImageFile(url);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        private byte[] Content { get; set; }



        public byte[] AsByteArray()
        {
            return this.Content;
        }

        // IMAGE PROCESSOR 
        public void Resize(int width, int height = 0)
        {
            Size size = new Size(width, height);
            using (MemoryStream inStream = new MemoryStream(this.Content))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Save(outStream);
                    }
                    this.Content = outStream.ToArray();
                }
            }
        }


        // HELPERS
        private static byte[] DownloadRemoteImageFile(string uri)
        {
            byte[] content;
            var request = (HttpWebRequest)WebRequest.Create(uri);

            using (var response = request.GetResponse())
            {
                content = ReadAllBytes(response.GetResponseStream());
            }

            return content;
        }

        private static byte[] ReadAllBytes(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}