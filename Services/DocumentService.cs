using Microsoft.EntityFrameworkCore;
using WinSoft.Data;
using WinSoft.Models;

namespace WinSoft.Services
{
    public class DocumentService
    {
        private readonly ApplicationDbContext _context;

        public DocumentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentTemplate> CreateDocumentTemplate(DocumentModel newDocumentTemplate)
        {
            var listField = new List<FieldOfDocumentTemplate>();
            foreach (var field in newDocumentTemplate.Fields)
            {
                listField.Add(new FieldOfDocumentTemplate()
                {
                    Name = field.Name,
                    IsEmpty = field.IsEmpty,
                    ValueType = field.ValueType
                });
            }

            var template = new DocumentTemplate()
            {
                Name = newDocumentTemplate.Name,
                FieldsOfDocumentTemplate = listField
            };

            await _context.DocumentTemplates.AddAsync(template);
            await _context.SaveChangesAsync();
            return template;
        }

        public async Task<SetOfDocumentsTemplateDTO> CreateNewSetOfDocumentsTemplate(SetOfDocumentsTemplateModel newSetOfDocumentTemplate)
        {
            var setOfDocument = new SetOfDocumentsTemplate()
            {
                Name = newSetOfDocumentTemplate.Name
            };
            foreach (var documentTemplateId in newSetOfDocumentTemplate.DocumentTemplateIds)
            {
                setOfDocument.UserDocuments.Add(await _context.DocumentTemplates.Where(doc => doc.Id == documentTemplateId).FirstAsync());
            }

            await _context.SetOfDocumentsTemplates.AddAsync(setOfDocument);
            await _context.SaveChangesAsync();
            return new()
            {
                Id = setOfDocument.Id,
                Name = setOfDocument.Name,
                TemplateIds = setOfDocument.UserDocuments.Select(doc => doc.Id).ToArray()
            };
        }
    }
}
