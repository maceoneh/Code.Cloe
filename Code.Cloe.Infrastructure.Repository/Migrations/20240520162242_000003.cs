using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Cloe.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _000003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "counters",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "master",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Province = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_master", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "detail",
                columns: table => new
                {
                    IDMasterDetail = table.Column<Guid>(type: "TEXT", nullable: false),
                    LineNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail", x => new { x.IDMasterDetail, x.LineNumber });
                    table.ForeignKey(
                        name: "FK_detail_master_IDMasterDetail",
                        column: x => x.IDMasterDetail,
                        principalTable: "master",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "counters");

            migrationBuilder.DropTable(
                name: "detail");

            migrationBuilder.DropTable(
                name: "master");
        }
    }
}
