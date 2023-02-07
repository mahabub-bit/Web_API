using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project01.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBusinessPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CGST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBankBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CC1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CC2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CC3 = table.Column<int>(type: "int", nullable: true),
                    CC4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
