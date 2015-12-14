using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;

namespace HaveYouSeenMe.Models.Business
{
    public class PetManagement
    {
        public static void CreateThumbnails(string fileName,string filePath,
            int thumbWi, int thumbHi, bool maintainAspect)
        {
            // Do something if the original is smaller than the designated
            // Thumbnail dimensions
            var originalFile = Path.Combine(filePath, fileName);
            var source = Image.FromFile(originalFile);
            int wi = thumbWi;
            int hi = thumbHi;


            if (source.Width <= thumbWi && source.Height <= thumbHi)
                return;
            Bitmap thumbnail;
            try
            {
              

                if (maintainAspect)
                {
                    // Maintain the aspect ratio despite the thumbnail size parameters
                    if (source.Width > source.Height)
                    {
                        wi = thumbWi;
                        hi = (int)(source.Height * ((decimal)thumbWi / source.Width));
                    }
                    else
                    {
                        hi = thumbHi;
                        wi = (int)(source.Width * ((decimal)thumbHi / source.Height));
                    }
                }
                thumbnail = new Bitmap(wi, hi);
                using (Graphics g = Graphics.FromImage(thumbnail))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(Brushes.Transparent, 0, 0, wi, hi);
                    g.DrawImage(source, 0, 0, wi, hi);
                }
                var thumbnailName = Path.Combine(filePath, "thumbnail_" + fileName);
                thumbnail.Save(thumbnailName);
            }
            catch (IOException io)
            {
                Console.WriteLine(io.ToString());
            }
        }
    }
}