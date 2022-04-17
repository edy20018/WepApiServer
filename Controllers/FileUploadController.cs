using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepApiServer.Models;

namespace WepApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment? _webHostEnvironment;

        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost,Authorize(Roles = "Admin")]
        public string Post([FromForm]FileUpload objectFile)
        {
            try {
                if (objectFile.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\versions\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
                    {
                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded.";
                    }
                }
                else
                {
                    return "Could not upload.";
                }

            }
            catch (Exception ex){
                return ex.Message;
            }

        }
    }
}
