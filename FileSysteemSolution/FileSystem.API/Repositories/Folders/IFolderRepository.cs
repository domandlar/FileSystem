using FileSystem.Domain.Entities;

namespace FileSystem.API.Repositories.Folders
{
    public interface IFolderRepository
    {
        Task<Folder> CreateFolderAsync(Folder folder);
        Task DeleteFolderAsync(int folderId);
        Task<bool> CheckIfFolderExistsByIdAsync(int folderId);
        Task<bool> CheckIfFolderExistsInFolderAsync(string folderName, int parentId);
    }
}
