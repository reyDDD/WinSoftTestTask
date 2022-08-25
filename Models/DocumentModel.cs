namespace WinSoft.Models
{
    public class DocumentModel
    {
        public string Name { get; set; } = null!;
        public IEnumerable<FieldOfDocumentModel> Fields { get; set; } = new List<FieldOfDocumentModel>();

    }
}
