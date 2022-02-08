using FileSystem.API.Repositories.Files;

namespace FileSystem.API.Services.Files
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Entities.File> CreateFileAsync(Entities.File file)
        {

            var fileExistsInFolder = await _fileRepository.CheckIfFileExistsInFolderAsync(file.Name, file.FolderId);
            if (fileExistsInFolder)
            {
                throw new Exception("File already exists!");
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
