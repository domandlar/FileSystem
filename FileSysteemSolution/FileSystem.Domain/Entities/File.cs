namespace FileSystem.Domain.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
    }
}
