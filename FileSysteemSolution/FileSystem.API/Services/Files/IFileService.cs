﻿namespace FileSystem.API.Services.Files
{
    public interface IFileService
    {
        Task<Entities.File> CreateFileAsync(Entities.File folder);
        Task DeleteFileAsync(int folderId);
        Task<List<string>> GetFilesByNameAsync(string fileName, int folderId);
    }
}
