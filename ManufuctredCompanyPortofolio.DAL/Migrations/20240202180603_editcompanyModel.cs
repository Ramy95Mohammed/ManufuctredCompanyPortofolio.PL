using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManufuctredCompanyPortofolio.DAL.Migrations
{
    public partial class editcompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manufcturingCompanies",
                columns: table => new
                {
                    KeyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufcturingCompanies", x => x.KeyID);
                });

            migrationBuilder.CreateTable(
                name: "ManuductringCompanyBranch",
                columns: table => new
                {
                    KeyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroundTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManufcturingCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuductringCompanyBranch", x => x.KeyID);
                    table.ForeignKey(
                        name: "FK_ManuductringCompanyBranch_manufcturingCompanies_ManufcturingCompanyId",
                        column: x => x.ManufcturingCompanyId,
                        principalTable: "manufcturingCompanies",
                        principalColumn: "KeyID");
                });

            migrationBuilder.CreateTable(
                name: "ManufcturingCompanyPhone",
                columns: table => new
                {
                    KeyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroundTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufcturingCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufcturingCompanyPhone", x => x.KeyID);
                    table.ForeignKey(
                        name: "FK_ManufcturingCompanyPhone_manufcturingCompanies_ManufcturingCompanyId",
                        column: x => x.ManufcturingCompanyId,
                        principalTable: "manufcturingCompanies",
                        principalColumn: "KeyID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManuductringCompanyBranch_ManufcturingCompanyId",
                table: "ManuductringCompanyBranch",
                column: "ManufcturingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufcturingCompanyPhone_ManufcturingCompanyId",
                table: "ManufcturingCompanyPhone",
                column: "ManufcturingCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManuductringCompanyBranch");

            migrationBuilder.DropTable(
                name: "ManufcturingCompanyPhone");

            migrationBuilder.DropTable(
                name: "manufcturingCompanies");
        }
    }
}
