using WinSoft.Models;

namespace WinSoft.Data
{
    public class FieldOfDocumentTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public FieldValueType ValueType { get; set; }
        public bool IsEmpty { get; set; }
    }
}
