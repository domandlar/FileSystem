using FileSystem.API.Repositories.Files;
using FileSystem.API.Repositories.Folders;

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

        public async Task<Entities.File> CreateFileAsync(Entities.File file)
        {

            var isFileExistsInFolder = await _fileRepository.CheckIfFileExistsInFolderAsync(file.Name, file.FolderId);
            if (isFileExistsInFolder)
            {
                throw new Exception("File already exists!");
            }
            var isFolderExists = await _folderRepository.CheckIfFolderExistsByIdAsync(file.FolderId);
            if (!isFolderExists)
            {
                throw new Exception("Folder does not exist!");
            }
            var createdFile = await _fileRepository.CreateFileAsync(file);
            return createdFile;
        }

        public async Task DeleteFileAsync(int fileId)
        {
            var fileExists = await _fileRepository.CheckIfFileExistsByIdAsync(fileId);
            if (!fileExists)
            {
                throw new Exception("File does not exist!");
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
