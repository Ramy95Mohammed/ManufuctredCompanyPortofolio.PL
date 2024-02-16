using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManufuctredCompanyPortofolio.DAL.Migrations
{
    public partial class manufuctredCompaniesBranchesResPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBranchesResponsiblePeople",
                columns: table => new
                {
                    KeyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonEnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufcturingCompanyId = table.Column<int>(type: "int", nullable: false),
                    ManuductringCompanyBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranchesResponsiblePeople", x => x.KeyID);
                    table.ForeignKey(
                        name: "FK_CompanyBranchesResponsiblePeople_ManuductringCompanyBranch_ManuductringCompanyBranchId",
                        column: x => x.ManuductringCompanyBranchId,
                        principalTable: "ManuductringCompanyBranch",
                        principalColumn: "KeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyBranchesResponsiblePeople_manufcturingCompanies_ManufcturingCompanyId",
                        column: x => x.ManufcturingCompanyId,
                        principalTable: "manufcturingCompanies",
                        principalColumn: "KeyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranchesResponsiblePeople_ManuductringCompanyBranchId",
                table: "CompanyBranchesResponsiblePeople",
                column: "ManuductringCompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranchesResponsiblePeople_ManufcturingCompanyId",
                table: "CompanyBranchesResponsiblePeople",
                column: "ManufcturingCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBranchesResponsiblePeople");
        }
    }
}
