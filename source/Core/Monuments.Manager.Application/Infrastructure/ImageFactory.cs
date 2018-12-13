using SkiaSharp;
using System;
using System.IO;

namespace Monuments.Manager.Application.Infrastructure
{
    public class ImageFactory : IImageFactory
    {
        private const int Size = 100;
        private const int Quality = 75;

        public string CreateThumbnail(byte[] data)
        {
            var input = new MemoryStream(data);
            var inputStream = new SKManagedStream(input);
            var output = new MemoryStream();
            using (var original = SKBitmap.Decode(inputStream))
            {
                int width, height;
                if (original.Width > original.Height)
                {
                    width = Size;
                    height = original.Height * Size / original.Width;
                }
                else
                {
                    width = original.Width * Size / original.Height;
                    height = Size;
                }

                using (var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium))
                {
                    using (var image = SKImage.FromBitmap(resized))
                    {
                        image.Encode(SKEncodedImageFormat.Png, Quality)
                             .SaveTo(output);

                        return Encode(output.ToArray());
                    }
                }
            }
        }

        public byte[] Decode(string image)
        {
            return Convert.FromBase64String(image);
        }

        public string Encode(byte[] image)
        {
            return Convert.ToBase64String(image);
        }
    }
}
