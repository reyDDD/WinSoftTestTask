using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSoft.Migrations
{
    public partial class UpdFieldTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldsOfDocumentTemplate_UserDocuments_UserDocumentId",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.DropIndex(
                name: "IX_FieldsOfDocumentTemplate_UserDocumentId",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.DropColumn(
                name: "UserDocumentId",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "FieldsOfDocumentTemplate");

            migrationBuilder.CreateTable(
                name: "FieldsOfDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldOfDocumentTemplateId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsOfDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldsOfDocument_UserDocuments_UserDocumentId",
                        column: x => x.UserDocumentId,
                        principalTable: "UserDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldsOfDocument_UserDocumentId",
                table: "FieldsOfDocument",
                column: "UserDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldsOfDocument");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FieldsOfDocumentTemplate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserDocumentId",
                table: "FieldsOfDocumentTemplate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FieldsOfDocumentTemplate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldsOfDocumentTemplate_UserDocumentId",
                table: "FieldsOfDocumentTemplate",
                column: "UserDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsOfDocumentTemplate_UserDocuments_UserDocumentId",
                table: "FieldsOfDocumentTemplate",
                column: "UserDocumentId",
                principalTable: "UserDocuments",
                principalColumn: "Id");
        }
    }
}
