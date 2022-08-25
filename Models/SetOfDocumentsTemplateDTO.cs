namespace WinSoft.Models
{
    public class SetOfDocumentsTemplateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int[] TemplateIds { get; set; } = null!;
    }
}
