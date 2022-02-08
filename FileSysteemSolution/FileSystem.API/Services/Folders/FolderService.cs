using FileSystem.API.Entities;
using FileSystem.API.Repositories.Folders;

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
                throw new Exception("Folder already exists!");
            }
            var createdFolder = await _folderRepository.CreateFolderAsync(folder);
            return createdFolder;
        }

        public async Task DeleteFolderAsync(int folderId)
        {
            var folderExists = await _folderRepository.CheckIfFolderExistsByIdAsync(folderId);
            if (!folderExists)
            {
                throw new Exception("Folder does not exist!");
            }
             await _folderRepository.DeleteFolderAsync(folderId);
        }
    }
}
