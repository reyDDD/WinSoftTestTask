using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSoft.Migrations
{
    public partial class AddUsersDocumentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDocumentTemplates_SetsOfDocuments_SetOfDocumentsId",
                table: "UserDocumentTemplates");

            migrationBuilder.DropIndex(
                name: "IX_UserDocumentTemplates_SetOfDocumentsId",
                table: "UserDocumentTemplates");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserDocumentTemplates");

            migrationBuilder.DropColumn(
                name: "SetOfDocumentsId",
                table: "UserDocumentTemplates");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserDocumentTemplates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SetsOfDocuments");

            migrationBuilder.AddColumn<int>(
                name: "SetOfDocumentsTemplateId",
                table: "SetsOfDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDocumentId",
                table: "FieldsOfDocumentTemplate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTemplateId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SetOfDocumentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocuments_DocumentTemplates_DocumentTemplateId",
                        column: x => x.DocumentTemplateId,
                        principalTable: "DocumentTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDocuments_SetsOfDocuments_SetOfDocumentsId",
                        column: x => x.SetOfDocumentsId,
                        principalTable: "SetsOfDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetsOfDocuments_SetOfDocumentsTemplateId",
                table: "SetsOfDocuments",
                column: "SetOfDocumentsTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsOfDocumentTemplate_UserDocumentId",
                table: "FieldsOfDocumentTemplate",
                column: "UserDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_DocumentTemplateId",
                table: "UserDocuments",
                column: "DocumentTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_SetOfDocumentsId",
                table: "UserDocuments",
                column: "SetOfDocumentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsOfDocumentTemplate_UserDocuments_UserDocumentId",
                table: "FieldsOfDocumentTemplate",
                column: "UserDocumentId",
                principalTable: "UserDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetsOfDocuments_SetOfDocumentsTemplates_SetOfDocumentsTemplateId",
                table: "SetsOfDocuments",
                column: "SetOfDocumentsTemplateId",
                principalTable: "SetOfDocumentsTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldsOfDocumentTemplate_UserDocuments_UserDocumentId",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_SetsOfDocuments_SetOfDocumentsTemplates_SetOfDocumentsTemplateId",
                table: "SetsOfDocuments");

            migrationBuilder.DropTable(
                name: "UserDocuments");

            migrationBuilder.DropIndex(
                name: "IX_SetsOfDocuments_SetOfDocumentsTemplateId",
                table: "SetsOfDocuments");

            migrationBuilder.DropIndex(
                name: "IX_FieldsOfDocumentTemplate_UserDocumentId",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.DropColumn(
                name: "SetOfDocumentsTemplateId",
                table: "SetsOfDocuments");

            migrationBuilder.DropColumn(
                name: "UserDocumentId",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserDocumentTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SetOfDocumentsId",
                table: "UserDocumentTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserDocumentTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SetsOfDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocumentTemplates_SetOfDocumentsId",
                table: "UserDocumentTemplates",
                column: "SetOfDocumentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocumentTemplates_SetsOfDocuments_SetOfDocumentsId",
                table: "UserDocumentTemplates",
                column: "SetOfDocumentsId",
                principalTable: "SetsOfDocuments",
                principalColumn: "Id");
        }
    }
}
