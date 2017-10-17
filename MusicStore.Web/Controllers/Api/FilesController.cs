using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Common;
using System;
using System.IO;

namespace MusicStore.Web.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Files")]
    public class FilesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("UploadSingleFile")]
        public IActionResult UploadSingleFile(IFormFile file)
        {
            try
            {
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/songs");

                var imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                string imageUrl = String.Format("uploads/songs/{0}", imageName);

                FileManagement.UploadSingleFile(file, uploadFolder, imageName);

                return Ok(imageUrl);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("DeleteSingleFile")]
        public IActionResult DeleteSingleFile(string fileUrl)
        {
            try
            {
                var dir = Path.Combine(_hostingEnvironment.WebRootPath, fileUrl);

                if (FileManagement.IsExisting(dir))
                {
                    FileManagement.DeleteFile(dir);

                    return Ok();
                }

                return NotFound("Couldn't locate the file!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}