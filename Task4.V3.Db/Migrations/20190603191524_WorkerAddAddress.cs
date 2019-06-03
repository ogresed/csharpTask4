using Microsoft.EntityFrameworkCore.Migrations;

namespace Task4.V3.Migrations
{
    public partial class WorkerAddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Workers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Workers");
        }
    }
}
