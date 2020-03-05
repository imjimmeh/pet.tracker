using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets.Tracker.Shared.Models.Migrations
{
    public partial class FixThing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Animals_AnimalId",
                table: "Breeds");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Breeds",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Animals_AnimalId",
                table: "Breeds",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Animals_AnimalId",
                table: "Breeds");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Breeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Animals_AnimalId",
                table: "Breeds",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
