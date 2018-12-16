using Monuments.Manager.Application.Pictures.Extensions;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Domain.Entities;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Infrastructure
{
    public class PictureDtoFactory : IPictureDtoFactory
    {
        private const int SmallWidth = 200, SmallHeight = 150;
        private const int MediumWidth = 500, MediumHeight = 400;
        private const int Quality = 50;

        public PictureDto Convert(PictureEntity pictureEntity, bool generateMultiSizeVersions)
        {
            if(pictureEntity is null)
            {
                return null;
            }
            var pictureDto = new PictureDto()
            {
                Description = pictureEntity.Description,
                Id = pictureEntity.Id,
            };

            var tasks = new List<Task>();
            tasks.Add(new Task(() => pictureDto.Small = Encode(pictureEntity.Data, SmallWidth, SmallHeight)));

            if (generateMultiSizeVersions)
            {
                tasks.Add(new Task(() => pictureDto.Original = pictureEntity.Data.Encode()));
                tasks.Add(new Task(() => pictureDto.Medium = Encode(pictureEntity.Data, MediumWidth, MediumHeight)));
            }

            tasks.ForEach(s => s.Start());
            Task.WaitAll(tasks.ToArray());

            return pictureDto;
        }

        private string Encode(byte[] data, int width, int height)
        {
            var input = new MemoryStream(data);
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

                        return output.ToArray().Encode();
                    }
                }
            }
        }
    }
}
