using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblEmploes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('2000-01-01 00:00:00')"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmploes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblTasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('2000-01-01 00:00:00')"),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('2000-01-01 00:00:00')"),
                    TblEmploeeID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TblTasks_TblEmploes_TblEmploeeID",
                        column: x => x.TblEmploeeID,
                        principalTable: "TblEmploes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblTasks_TblEmploeeID",
                table: "TblTasks",
                column: "TblEmploeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblTasks");

            migrationBuilder.DropTable(
                name: "TblEmploes");
        }
    }
}
