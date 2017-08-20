using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Common
{
    public class ImageMaker
    {

        // todo : make the setText


        public void MakeGifImage(string gifFileName, Dictionary<string, string> appendDic)
        {
            Bitmap bitmap = new Bitmap(1024, 680);
            Graphics graphics = Graphics.FromImage(bitmap);
            int red = 0;
            int white = 11;

            while (white <= 100)
            {
                graphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                graphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFile = Path.Combine(baseDirectory, gifFileName);
            bitmap.Save(saveFile, System.Drawing.Imaging.ImageFormat.Gif);
        }

    }
}