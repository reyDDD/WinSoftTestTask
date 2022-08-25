namespace WinSoft.Data
{
    public class DocumentTemplate
    {
        public string Name { get; set; } = null!;
        public int Id { get; set; }

        public int? SetOfDocumentsTemplateId { get; set; }
        public SetOfDocumentsTemplate? SetOfDocumentsTemplate { get; set; }
        public IEnumerable<FieldOfDocumentTemplate> FieldsOfDocumentTemplate { get; set; } = new List<FieldOfDocumentTemplate>();

    }
}
