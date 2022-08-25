using WinSoft.Models;

namespace WinSoft.Data
{
    public class SetOfDocuments
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public Status Status { get; set; }
        public int SetOfDocumentsTemplateId { get; set; }
        public SetOfDocumentsTemplate SetOfDocumentsTemplate { get; set; } = null!;
        public List<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();
    }
}
