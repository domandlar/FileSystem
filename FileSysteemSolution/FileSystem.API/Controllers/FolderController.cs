using FileSystem.API.Models.Foldes.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateFolder([FromBody]CreateFolderRequest createFolderRequest)
        {


            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFolder(int folderId)
        {

            return Ok();
        }
    }
}
