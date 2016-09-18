using System;

namespace ImageService.Models
{
    // Type-Safe-Enum pattern 
    // http://stackoverflow.com/questions/424366/c-sharp-string-enums
    public sealed class MediaType
    {
        private readonly String name;
        private readonly int value;

        public static readonly MediaType JPEG = new MediaType(1, "image/jpeg");
        public static readonly MediaType WINDOWSAUTHENTICATION = new MediaType(2, "WINDOWS");
        public static readonly MediaType SINGLESIGNON = new MediaType(3, "SSN");

        private MediaType(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }

    }
}