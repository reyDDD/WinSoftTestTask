using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSoft.Migrations
{
    public partial class UpdDocumentTemplate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTemplates_SetOfDocumentsTemplates_SetOfDocumentsTemplateId",
                table: "DocumentTemplates");

            migrationBuilder.AlterColumn<int>(
                name: "SetOfDocumentsTemplateId",
                table: "DocumentTemplates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTemplates_SetOfDocumentsTemplates_SetOfDocumentsTemplateId",
                table: "DocumentTemplates",
                column: "SetOfDocumentsTemplateId",
                principalTable: "SetOfDocumentsTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTemplates_SetOfDocumentsTemplates_SetOfDocumentsTemplateId",
                table: "DocumentTemplates");

            migrationBuilder.AlterColumn<int>(
                name: "SetOfDocumentsTemplateId",
                table: "DocumentTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTemplates_SetOfDocumentsTemplates_SetOfDocumentsTemplateId",
                table: "DocumentTemplates",
                column: "SetOfDocumentsTemplateId",
                principalTable: "SetOfDocumentsTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
