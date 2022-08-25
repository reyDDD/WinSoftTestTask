using WinSoft.Models;

namespace WinSoft.Data
{
    public class SetOfDocumentsTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<DocumentTemplate> UserDocuments { get; set; } = new List<DocumentTemplate>();
    }
}
