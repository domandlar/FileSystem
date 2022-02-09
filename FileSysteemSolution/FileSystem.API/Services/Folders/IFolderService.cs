using FileSystem.Domain.Entities;

namespace FileSystem.API.Services.Folders
{
    public interface IFolderService
    {
        Task<Folder> CreateFolderAsync(Folder folder);
        Task DeleteFolderAsync(int folderId);
    }
}
