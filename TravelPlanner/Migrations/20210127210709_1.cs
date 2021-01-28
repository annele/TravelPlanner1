using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlanner.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityResults",
                columns: table => new
                {
                    ID2 = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityResults", x => x.ID2);
                });

            migrationBuilder.CreateTable(
                name: "LocationInformations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInformations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CafeResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AveragePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CafeAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CafeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CafeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CafeResults_LocationInformations_CityID",
                        column: x => x.CityID,
                        principalTable: "LocationInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NightSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaySummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadlineText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempDay = table.Column<double>(type: "float", nullable: false),
                    TempNight = table.Column<double>(type: "float", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeatherResults_LocationInformations_CityID",
                        column: x => x.CityID,
                        principalTable: "LocationInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CafeResults_CityID",
                table: "CafeResults",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherResults_CityID",
                table: "WeatherResults",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CafeResults");

            migrationBuilder.DropTable(
                name: "CityResults");

            migrationBuilder.DropTable(
                name: "WeatherResults");

            migrationBuilder.DropTable(
                name: "LocationInformations");
        }
    }
}
