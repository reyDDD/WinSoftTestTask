using Microsoft.EntityFrameworkCore;
using WinSoft.Data;
using WinSoft.Models;

namespace WinSoft.Services
{
    public class SetOfDocumentsServices
    {
        private readonly ApplicationDbContext _context;
        private readonly FieldRestrictionsService _checkRestrictionsService;

        public SetOfDocumentsServices(ApplicationDbContext context,
            FieldRestrictionsService checkRestrictionsService)
        {
            _context = context;
            _checkRestrictionsService = checkRestrictionsService;
        }


        public async Task<List<SetOfDocuments>> GetSetOfDocuments()
        {
            return await _context.SetsOfDocuments.ToListAsync();
        }

        public async Task<StatusOperation> ChangeStatusSetOfDocuments(int setOfDocumentsId, Status newStatus)
        {
            var set = await _context.SetsOfDocuments
                .Include(doc => doc.UserDocuments)
                .Where(doc => doc.Id == setOfDocumentsId)
                .FirstOrDefaultAsync();
            if (set == null || set.UserDocuments.Any(doc => doc.Status != Status.Verified))
            {
                return StatusOperation.Error;
            }
            else if (newStatus != Status.Verified)
            {
                set.Status = newStatus;
                await _context.SaveChangesAsync();
            }
            else
            {
                set.Status = Status.Verified;
                await _context.SaveChangesAsync();
            }
            return StatusOperation.Success;
        }

        public async Task<StatusOperation> CreateSetOfDocuments(SetOfDocumentsModel setOfDocumeModel, string userId)
        {
            List<UserDocument> documents = new();

            SetOfDocuments set = new()
            {
                SetOfDocumentsTemplateId = setOfDocumeModel.SetOfDocumentsTemplateId,
                Status = Status.NotSet,
                UserId = userId,
                UserDocuments = documents
            };

            foreach (var document in setOfDocumeModel.Documents)
            {
                var docTemplate = await _context!.DocumentTemplates.Where(doc => doc.Id == document.DocumentTemplateId).FirstOrDefaultAsync();
                List<FieldOfDocument> fields = new();
                foreach (var field in document.Fields)
                {
                    fields.Add(new()
                    {
                        Value = field.Value,
                        FieldOfDocumentTemplateId = field.FieldOfDocumentTemplateId
                    });
                }
                documents.Add(new UserDocument()
                {
                    Status = await _checkRestrictionsService.Check(document, _context),
                    DocumentTemplate = docTemplate!,
                    FieldsOfDocumentTemplate = fields
                });
            }
            await _context.SetsOfDocuments.AddAsync(set);
            await _context.SaveChangesAsync();
            return StatusOperation.Success;
        }

        public async Task<Status> CheckStatusSetOfDocuments(int setId, string userId)
        {
            return await _context.SetsOfDocuments
                .Where(set => set.Id == setId && set.UserId == userId)
                .Select(doc => doc.Status)
                .FirstAsync();
        }
    }
}
