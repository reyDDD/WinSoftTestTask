namespace WinSoft.Models
{
    public class DocumentInputModel
    {
        public int DocumentTemplateId { get; set; }
        public List<FieldOfDocumentTemplateModel> Fields { get; set; } = new();

    }
}
