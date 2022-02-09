namespace FileSystem.Domain.Models.Foldes.Requests
{
    public class CreateFolderRequest
    {
        public string FolderName { get; set; }
        public int? ParentFolderId { get; set; }
    }
}
