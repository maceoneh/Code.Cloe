using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Cloe.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Migration000002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phones_subjects_SubjectID",
                table: "phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phones",
                table: "phones");

            migrationBuilder.RenameTable(
                name: "phones",
                newName: "contacts");

            migrationBuilder.RenameIndex(
                name: "IX_phones_SubjectID",
                table: "contacts",
                newName: "IX_contacts_SubjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_subjects_SubjectID",
                table: "contacts",
                column: "SubjectID",
                principalTable: "subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_subjects_SubjectID",
                table: "contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "phones");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_SubjectID",
                table: "phones",
                newName: "IX_phones_SubjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phones",
                table: "phones",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_phones_subjects_SubjectID",
                table: "phones",
                column: "SubjectID",
                principalTable: "subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
