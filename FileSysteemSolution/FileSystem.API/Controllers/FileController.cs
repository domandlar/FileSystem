using FileSystem.Application.Services.Files;
using FileSystem.Domain.Models.Files.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFileAsync([FromBody] CreateFileRequest createFileRequest)
        {
            var newFolder = new Domain.Entities.File
            {
                Name = createFileRequest.FileName,
                FolderId = createFileRequest.FolderId
            };
            var createdFolder = await _fileService.CreateFileAsync(newFolder);
            return Ok(createdFolder);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFileAsync(int fileId)
        {
            await _fileService.DeleteFileAsync(fileId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetFileAsync(string fileName, int folderId)
        {
            var files = await _fileService.GetFilesByNameAsync(fileName, folderId);
            return Ok(files);
        }
    }
}
