using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Monuments.Manager.Application.Infrastructure
{
    public class ThumbnailImageFactory : IThumbnailImageFactory
    {
        private const int MaxHeight = 150;
        private const int MaxWidth = 150;

        public byte[] Create(byte[] image)
        {
            var inputStream = new MemoryStream(image);
            var current = Image.FromStream(inputStream);

            int width, height;

            if (current.Width > current.Height)
            {
                width = MaxWidth;
                height = Convert.ToInt32(current.Height * MaxHeight / (double)current.Width);
            }
            else
            {
                width = Convert.ToInt32(current.Width * MaxWidth / (double)current.Height);
                height = MaxHeight;
            }

            var canvas = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(canvas))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(current, 0, 0, width, height);
            }

            return GetRawImage(canvas);
        }

        private byte[] GetRawImage(Bitmap canvas)
        {
            var outputStream = new MemoryStream();
            canvas.Save(outputStream, ImageFormat.Jpeg);

            var result = new byte[outputStream.Length];
            outputStream.Read(result, 0, (int)outputStream.Length);

            return result;
        }
    }
}
