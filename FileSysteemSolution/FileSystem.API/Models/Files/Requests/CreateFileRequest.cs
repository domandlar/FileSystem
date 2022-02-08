namespace FileSystem.API.Models.Files.Requests
{
    public class CreateFileRequest
    {
        public string FileName { get; set; }
        public int FolderId { get; set; }
    }
}
