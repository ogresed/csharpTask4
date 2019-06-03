using Microsoft.EntityFrameworkCore.Migrations;

namespace Task4.V3.Migrations
{
    public partial class RenameFolders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Projects",
                newName: "WorkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_WorkerId",
                table: "Projects",
                newName: "IX_Projects_WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Workers_WorkerID",
                table: "Projects",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Workers_WorkerID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "WorkerID",
                table: "Projects",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_WorkerID",
                table: "Projects",
                newName: "IX_Projects_WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
