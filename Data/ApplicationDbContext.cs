using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinSoft.Models;

namespace WinSoft.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<FieldOfDocument> FieldsOfDocument { get; set; }
        public DbSet<FieldOfDocumentTemplate> FieldsOfDocumentTemplate { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<UserDocumentTemplate> UserDocumentTemplates { get; set; }
        public DbSet<SetOfDocuments> SetsOfDocuments { get; set; }
        public DbSet<SetOfDocumentsTemplate> SetOfDocumentsTemplates { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
