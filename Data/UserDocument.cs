using WinSoft.Models;

namespace WinSoft.Data
{
    public class UserDocument
    {
        public int Id { get; set; }
        public int DocumentTemplateId { get; set; }
        public DocumentTemplate DocumentTemplate { get; set; } = new();
        public Status Status { get; set; }
        public IEnumerable<FieldOfDocument> FieldsOfDocumentTemplate { get; set; } = new List<FieldOfDocument>();

    }
}
