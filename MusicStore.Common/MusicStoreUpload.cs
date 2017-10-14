using Microsoft.AspNetCore.Http;
using System.IO;

namespace MusicStore.Common
{
    public class MusicStoreUpload
    {
        public static void UploadSingleFile(IFormFile fileToUpload, string uploadFolder, string imageName)
        {
            string savePath = Path.Combine(uploadFolder, imageName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                fileToUpload.CopyTo(fileStream);
            }
        }
    }
}