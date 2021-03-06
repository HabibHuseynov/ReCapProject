using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var sourcePath = currentDir + "\\wwwroot\\images\\";
            if (CheckFileisNull(file))
            {
                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }
                var result = sourcePath + NewPath(file);


                using (FileStream stream = System.IO.File.Create(result))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }



                return result;
            }
            return sourcePath + "default.jpg";
            



        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);

            using (FileStream stream = System.IO.File.Create(result))
            {
                file.CopyTo(stream);
                stream.Flush();
            }

            Delete(sourcePath);
            return result;
        }
        private static string NewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var fileExtension = Path.GetExtension(file.ToString());
            var pathFileGUID = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string result = pathFileGUID;
            return result;
        }
        private static bool CheckFileisNull(IFormFile file)
        {
            if (file == null)
            {
                return false;
            }
            return true;
        }
    }
}
