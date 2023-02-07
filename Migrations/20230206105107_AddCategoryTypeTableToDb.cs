using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project01.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTypeTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CatTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatTypeDesc2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatTypeDesc3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatTypeDesc4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_CompanyId",
                table: "CategoryTypes",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTypes");
        }
    }
}
