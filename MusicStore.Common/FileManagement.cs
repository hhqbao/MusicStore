using Microsoft.AspNetCore.Http;
using System.IO;

namespace MusicStore.Common
{
    public class FileManagement
    {
        public static void UploadSingleFile(IFormFile fileToUpload, string uploadFolder, string imageName)
        {
            string savePath = Path.Combine(uploadFolder, imageName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                fileToUpload.CopyTo(fileStream);
            }
        }

        public static void DeleteFile(string fileDirectory)
        {
            if (IsExisting(fileDirectory))
                File.Delete(fileDirectory);
        }

        public static bool IsExisting(string fileDirectory)
        {
            return File.Exists(fileDirectory);
        }
    }
}