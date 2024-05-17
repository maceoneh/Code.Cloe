using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Cloe.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _000001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDateTime",
                table: "subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "subjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDateTime",
                table: "contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "contacts");
        }
    }
}
