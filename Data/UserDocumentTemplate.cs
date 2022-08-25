namespace WinSoft.Data
{
    public class UserDocumentTemplate
    {
        public int Id { get; set; }
        public int DocumentTemplateId { get; set; }
        public DocumentTemplate DocumentTemplate { get; set; } = new();
    }
}
