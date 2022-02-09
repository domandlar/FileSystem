using FileSystem.Domain.Entities;

namespace FileSystem.Application.Services.Folders
{
    public interface IFolderService
    {
        Task<Folder> CreateFolderAsync(Folder folder);
        Task DeleteFolderAsync(int folderId);
    }
}
