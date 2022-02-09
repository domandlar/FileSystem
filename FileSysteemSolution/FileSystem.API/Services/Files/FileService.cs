using FileSystem.API.Repositories.Files;
using FileSystem.API.Repositories.Folders;
using FileSystem.Domain.Exeptions;

namespace FileSystem.API.Services.Files
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFolderRepository _folderRepository;

        public FileService(IFileRepository fileRepository, IFolderRepository folderRepository)
        {
            _fileRepository = fileRepository;
            _folderRepository = folderRepository;
        }

        public async Task<Domain.Entities.File> CreateFileAsync(Domain.Entities.File file)
        {

            var isFileExistsInFolder = await _fileRepository.CheckIfFileExistsInFolderAsync(file.Name, file.FolderId);
            if (isFileExistsInFolder)
            {
                throw new AppException("File already exists!");
            }
            var isFolderExists = await _folderRepository.CheckIfFolderExistsByIdAsync(file.FolderId);
            if (!isFolderExists)
            {
                throw new AppException("Folder does not exist!");
            }
            var createdFile = await _fileRepository.CreateFileAsync(file);
            return createdFile;
        }

        public async Task DeleteFileAsync(int fileId)
        {
            var fileExists = await _fileRepository.CheckIfFileExistsByIdAsync(fileId);
            if (!fileExists)
            {
                throw new AppException("File does not exist!");
            }
            await _fileRepository.DeleteFileAsync(fileId);
        }

        public async Task<List<string>> GetFilesByNameAsync(string fileName, int folderId)
        {
            if (folderId < 1)
            {
                folderId = 1;
            }
            return await _fileRepository.GetFilesByNameAsync(fileName, folderId);
        }
    }
}
