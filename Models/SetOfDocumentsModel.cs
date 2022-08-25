namespace WinSoft.Models
{
    public class SetOfDocumentsModel
    {
        public int SetOfDocumentsTemplateId { get; set; }
        public List<DocumentInputModel> Documents { get; set; } = new();
    }
}
