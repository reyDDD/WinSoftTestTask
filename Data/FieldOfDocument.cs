using WinSoft.Models;

namespace WinSoft.Data
{
    public class FieldOfDocument 
    {
        public int Id { get; set; }
        public int FieldOfDocumentTemplateId { get; set; }
        public string Value { get; set; } = null!;
    }
}
