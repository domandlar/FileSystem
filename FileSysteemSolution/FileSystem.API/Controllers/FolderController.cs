using FileSystem.API.Services.Folders;
using FileSystem.Domain.Entities;
using FileSystem.Domain.Models.Foldes.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;
        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolderAsync([FromBody]CreateFolderRequest createFolderRequest)
        {
            var newFolder = new Folder
            {
                Name = createFolderRequest.FolderName,
                ParentId = createFolderRequest.ParentFolderId.Value
            };
            var createdFolder = await _folderService.CreateFolderAsync(newFolder);
            return Ok(createdFolder);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFolderAsync(int folderId)
        {
            await _folderService.DeleteFolderAsync(folderId);
            return Ok();
        }
    }
}
