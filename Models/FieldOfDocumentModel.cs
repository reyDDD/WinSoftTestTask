namespace WinSoft.Models
{
    public class FieldOfDocumentModel
    {
        public string Name { get; set; } = null!;
        public FieldValueType ValueType { get; set; }
        public bool IsEmpty { get; set; }
        public string? Value { get; set; }
    }
}
