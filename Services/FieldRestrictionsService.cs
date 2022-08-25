using Microsoft.EntityFrameworkCore;
using WinSoft.Data;
using WinSoft.Models;

namespace WinSoft.Services
{
    public class FieldRestrictionsService
    {
        public async Task< Status> Check(DocumentInputModel model, ApplicationDbContext context)
        {
            foreach (var field in model.Fields)
            {
              var isChecked = await CheckFieldValue(field, context);
                if (isChecked) return Status.Verified;
            }
            return Status.NotSet;
        }


        private async Task<bool> CheckFieldValue(FieldOfDocumentTemplateModel field, ApplicationDbContext context)
        {
            var type = await context.FieldsOfDocumentTemplate
                .Where(field => field.Id == field.Id)
                .Select(field => field.ValueType).FirstOrDefaultAsync();

            switch (type)
            {
                case FieldValueType.NotSet:
                    return false;
                case FieldValueType.Int:
                    if (Convert.ToInt32(field.Value) > 0 && Convert.ToInt32(field.Value) < 10000)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case FieldValueType.String:
                    if (!String.IsNullOrEmpty(field.Value) || !field.Value!.Contains(',')) //и другие символы
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case FieldValueType.DateTime:
                    var date = Convert.ToDateTime(field.Value);
                    if (date > date.AddYears(-100) && date < date.AddYears(100))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
