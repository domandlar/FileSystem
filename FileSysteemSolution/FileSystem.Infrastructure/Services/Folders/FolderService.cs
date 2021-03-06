using FileSystem.API.Repositories.Folders;
using FileSystem.Application.Repositories.Folders;
using FileSystem.Application.Services.Folders;
using FileSystem.Domain.Entities;
using FileSystem.Domain.Exeptions;

namespace FileSystem.API.Services.Folders
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public async Task<Folder> CreateFolderAsync(Folder folder)
        {
            if (!folder.ParentId.HasValue || folder.ParentId < 1)
            {
                folder.ParentId = 1;
            }
            var folderExistsInFolder = await _folderRepository.CheckIfFolderExistsInFolderAsync(folder.Name, folder.ParentId.Value);
            if (folderExistsInFolder)
            {
                throw new AppException("Folder already exists!");
            }
            var createdFolder = await _folderRepository.CreateFolderAsync(folder);
            return createdFolder;
        }

        public async Task DeleteFolderAsync(int folderId)
        {
            var folderExists = await _folderRepository.CheckIfFolderExistsByIdAsync(folderId);
            if (!folderExists)
            {
                throw new AppException("Folder does not exist!");
            }
             await _folderRepository.DeleteFolderAsync(folderId);
        }
    }
}
