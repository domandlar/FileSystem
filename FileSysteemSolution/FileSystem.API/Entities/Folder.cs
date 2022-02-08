namespace FileSystem.API.Entities
{
    public class Folder : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
