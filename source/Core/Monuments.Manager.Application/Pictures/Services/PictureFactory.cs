using Monuments.Manager.Application.Pictures.Commands;
using Monuments.Manager.Domain.Entities;
using SkiaSharp;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Monuments.Manager.Application.Infrastructure
{
    public class PictureFactory : IPictureFactory
    {
        private const int SmallWidth = 200, SmallHeight = 150;
        private const int MediumWidth = 500, MediumHeight = 400;
        private const int Quality = 50;

        public PictureEntity Create(CreatePictureCommand command)
        {
            var base64Data = Regex.Match(command.Data, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var pictureDto = new PictureEntity()
            {
                Description = command.Description,
                Original = base64Data,
                MonumentId = command.MonumentId,
                Medium = Encode(base64Data, MediumWidth, MediumHeight),
                Small = Encode(base64Data, SmallWidth, SmallHeight)
            };

            return pictureDto;
        }

        private string Encode(string data, int width, int height)
        {
            var input = new MemoryStream(Convert.FromBase64String(data));
            var inputStream = new SKManagedStream(input);
            var output = new MemoryStream();
            using (var original = SKBitmap.Decode(inputStream))
            {
                using (var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium))
                {
                    using (var image = SKImage.FromBitmap(resized))
                    {
                        image.Encode(SKEncodedImageFormat.Png, Quality)
                             .SaveTo(output);

                        return Convert.ToBase64String(output.ToArray());
                    }
                }
            }
        }
    }
}
