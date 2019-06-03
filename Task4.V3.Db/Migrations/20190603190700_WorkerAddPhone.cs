using Microsoft.EntityFrameworkCore.Migrations;

namespace Task4.V3.Migrations
{
    public partial class WorkerAddPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Workers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Workers");
        }
    }
}
