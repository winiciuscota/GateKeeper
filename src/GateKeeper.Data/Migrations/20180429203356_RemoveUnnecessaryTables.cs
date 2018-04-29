using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GateKeeper.Data.Migrations
{
    public partial class RemoveUnnecessaryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentAparments");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "CondominiumBlocks");

            migrationBuilder.DropTable(
                name: "Condominiums");

            migrationBuilder.AddColumn<string>(
                name: "Apartment",
                table: "Residents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Block",
                table: "Residents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Block",
                table: "Residents");

            migrationBuilder.CreateTable(
                name: "Condominiums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address_AddressNumber = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Complement = table.Column<string>(nullable: true),
                    Address_Neighborhood = table.Column<string>(nullable: true),
                    Address_PostCode = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_StreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CondominiumBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CondominiumId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominiumBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CondominiumBlocks_Condominiums_CondominiumId",
                        column: x => x.CondominiumId,
                        principalTable: "Condominiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CondominiumBlockId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_CondominiumBlocks_CondominiumBlockId",
                        column: x => x.CondominiumBlockId,
                        principalTable: "CondominiumBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentAparments",
                columns: table => new
                {
                    ResidentId = table.Column<int>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentAparments", x => new { x.ResidentId, x.ApartmentId });
                    table.ForeignKey(
                        name: "FK_ResidentAparments_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentAparments_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CondominiumBlockId",
                table: "Apartments",
                column: "CondominiumBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_CondominiumBlocks_CondominiumId",
                table: "CondominiumBlocks",
                column: "CondominiumId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAparments_ApartmentId",
                table: "ResidentAparments",
                column: "ApartmentId");
        }
    }
}
