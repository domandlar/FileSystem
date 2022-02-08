namespace FileSystem.API.Entities
{
    public class File : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
    }
}
