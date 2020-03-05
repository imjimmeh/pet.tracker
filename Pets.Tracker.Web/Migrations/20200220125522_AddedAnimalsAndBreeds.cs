using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets.Tracker.Web.Migrations
{
    public partial class AddedAnimalsAndBreeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_AspNetUsers_PetsTrackerUserId",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_PetsTrackerUserId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PetsTrackerUserId",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroomingRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingRecord_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementsRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    Height = table.Column<decimal>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    Depth = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementsRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementsRecord_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trick",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trick", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trick_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VetVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VetVisit_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToiletRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: true),
                    ColourId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToiletRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToiletRecord_Colour_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToiletRecord_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrickRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrickId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrickRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrickRecord_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrickRecord_Trick_TrickId",
                        column: x => x.TrickId,
                        principalTable: "Trick",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AnimalId",
                table: "Pets",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedId",
                table: "Pets",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_AnimalId",
                table: "Breeds",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingRecord_PetId",
                table: "GroomingRecord",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementsRecord_PetId",
                table: "MeasurementsRecord",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_ToiletRecord_ColourId",
                table: "ToiletRecord",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_ToiletRecord_PetId",
                table: "ToiletRecord",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Trick_PetId",
                table: "Trick",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_TrickRecord_PetId",
                table: "TrickRecord",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_TrickRecord_TrickId",
                table: "TrickRecord",
                column: "TrickId");

            migrationBuilder.CreateIndex(
                name: "IX_VetVisit_PetId",
                table: "VetVisit",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Animals_AnimalId",
                table: "Pets",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Animals_AnimalId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "GroomingRecord");

            migrationBuilder.DropTable(
                name: "MeasurementsRecord");

            migrationBuilder.DropTable(
                name: "ToiletRecord");

            migrationBuilder.DropTable(
                name: "TrickRecord");

            migrationBuilder.DropTable(
                name: "VetVisit");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.DropTable(
                name: "Trick");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AnimalId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BreedId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.AddColumn<string>(
                name: "PetsTrackerUserId",
                table: "Pet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetsTrackerUserId",
                table: "Pet",
                column: "PetsTrackerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_AspNetUsers_PetsTrackerUserId",
                table: "Pet",
                column: "PetsTrackerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
