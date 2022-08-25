namespace WinSoft.Models
{
    public class DocumentTemplateModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<FieldOfDocumentModel> Fields { get; set; } = new List<FieldOfDocumentModel>();
    }
}
