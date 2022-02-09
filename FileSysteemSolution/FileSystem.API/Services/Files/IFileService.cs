namespace FileSystem.API.Services.Files
{
    public interface IFileService
    {
        Task<Domain.Entities.File> CreateFileAsync(Domain.Entities.File folder);
        Task DeleteFileAsync(int folderId);
        Task<List<string>> GetFilesByNameAsync(string fileName, int folderId);
    }
}
