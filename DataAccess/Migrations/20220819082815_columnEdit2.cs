using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class columnEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İmage1",
                table: "Products",
                newName: "Image1");

            migrationBuilder.RenameColumn(
                name: "DistrictsName",
                table: "Districts",
                newName: "DistrictName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Products",
                newName: "İmage1");

            migrationBuilder.RenameColumn(
                name: "DistrictName",
                table: "Districts",
                newName: "DistrictsName");
        }
    }
}
