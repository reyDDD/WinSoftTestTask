namespace WinSoft.Models
{
    public class SetOfDocumentsTemplateModel
    {
        public string Name { get; set; } = null!;
        public List<int> DocumentTemplateIds { get; set; } = new();
    }
}
