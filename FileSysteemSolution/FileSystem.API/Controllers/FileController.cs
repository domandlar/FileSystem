using FileSystem.API.Models.Files.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult CreateFile([FromBody] CreateFileRequest createFileRequest)
        {

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFile(int fileId)
        {

            return Ok();
        }
    }
}
