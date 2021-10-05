using BotDetect;
using System;
using System.Diagnostics;
using System.IO;

namespace BotDetectCaptcha
{
    class Program
    {
        static void Main()
        {
            for (var i = 0; i <= 10000; i++)
            {
                #region Get BotDetect Captcha image
                CaptchaBase captchaBase = new CaptchaBase("CaptchaCode");
                MemoryStream captchaImage = captchaBase.GetImage("CaptchaCode");
                #endregion

                #region Save BotDetect Captcha images
                SaveImage(captchaImage, i);
                #endregion
            }
        }

        private static MemoryStream SaveImage(MemoryStream image, int countForImages)
        {
            var destinationFileName = "botdetect.jpg";
            var destinationDirectory = @"C:\BotDetect Captchas\";
            var destinationPath = destinationDirectory + (countForImages + "_" + destinationFileName);

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            using (FileStream file = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                image.WriteTo(file);
            }

            Console.WriteLine($"Successfully downloaded botDetect captcha images with destination \"{destinationPath}\" returns '{destinationDirectory}'");

            return image;
        }
    }
}
