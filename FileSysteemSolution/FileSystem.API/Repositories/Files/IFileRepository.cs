namespace FileSystem.API.Repositories.Files
{
    public interface IFileRepository
    {
        Task<Entities.File> CreateFileAsync(Entities.File file);
        Task DeleteFileAsync(int fileId);
        Task<bool> CheckIfFileExistsByIdAsync(int fileId);
        Task<bool> CheckIfFileExistsInFolderAsync(string fileName, int parentId);
        Task<List<Entities.File>> GetFilesByNameAsync();
    }
}
