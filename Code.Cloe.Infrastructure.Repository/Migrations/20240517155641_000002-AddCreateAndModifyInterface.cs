using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Cloe.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _000002AddCreateAndModifyInterface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDateTime",
                table: "subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "ModifyDateTime",
                table: "subjects");
        }
    }
}
