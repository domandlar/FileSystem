namespace FileSystem.Application.Repositories.Files
{
    public interface IFileRepository
    {
        Task<Domain.Entities.File> CreateFileAsync(Domain.Entities.File file);
        Task DeleteFileAsync(int fileId);
        Task<bool> CheckIfFileExistsByIdAsync(int fileId);
        Task<bool> CheckIfFileExistsInFolderAsync(string fileName, int folderId);
        Task<List<string>> GetFilesByNameAsync(string fileName, int folderId);
    }
}
