using Microsoft.EntityFrameworkCore.Migrations;

namespace MyportFolio1.Migrations
{
    public partial class Abdallah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAboutme");

            migrationBuilder.DropTable(
                name: "TBcontctme");

            migrationBuilder.DropTable(
                name: "TBmycard");

            migrationBuilder.DropTable(
                name: "TBmyserves");

            migrationBuilder.DropTable(
                name: "TBResme");

            migrationBuilder.DropTable(
                name: "TBslider");
        }
    }
}
