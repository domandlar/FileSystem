﻿using FileSystem.API.Models.Files.Requests;
using FileSystem.API.Services.Files;
using Microsoft.AspNetCore.Http;
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
            var newFolder = new Entities.File
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
    }
}
