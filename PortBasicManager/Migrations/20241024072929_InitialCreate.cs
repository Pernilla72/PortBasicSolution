using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortBasicManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occupancy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VesselId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FreeSlots = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.SlotId);
                });

            migrationBuilder.CreateTable(
                name: "RejectedVessels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VesselId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedVessel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    VesselId = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    VesselType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VesselSize = table.Column<double>(type: "float", nullable: false),
                    WeightInKg = table.Column<double>(type: "float", nullable: true),
                    SpeedInKnots = table.Column<double>(type: "float", nullable: true),
                    LayTime = table.Column<int>(type: "int", nullable: true),
                    PortSlotId = table.Column<int>(type: "int", nullable: false),
                    NumberOfContainers = table.Column<int>(type: "int", nullable: true),
                    NumberOfHorsepower = table.Column<double>(type: "float", nullable: true),
                    NumberOfPassengers = table.Column<int>(type: "int", nullable: true),
                    LengthOfSailboat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessel", x => x.VesselId);
                    table.ForeignKey(
                        name: "FK_Vessels_Ports_PortSlotId",
                        column: x => x.PortSlotId,
                        principalTable: "Ports",
                        principalColumn: "SlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ports",
                columns: new[] { "SlotId", "FreeSlots", "Id", "Occupancy", "VesselId" },
                values: new object[,]
                {
                    { 1, null, 1, 0m, null },
                    { 2, null, 2, 0m, null },
                    { 3, null, 3, 0m, null },
                    { 4, null, 4, 0m, null },
                    { 5, null, 5, 0m, null },
                    { 6, null, 6, 0m, null },
                    { 7, null, 7, 0m, null },
                    { 8, null, 8, 0m, null },
                    { 9, null, 9, 0m, null },
                    { 10, null, 10, 0m, null },
                    { 11, null, 11, 0m, null },
                    { 12, null, 12, 0m, null },
                    { 13, null, 13, 0m, null },
                    { 14, null, 14, 0m, null },
                    { 15, null, 15, 0m, null },
                    { 16, null, 16, 0m, null },
                    { 17, null, 17, 0m, null },
                    { 18, null, 18, 0m, null },
                    { 19, null, 19, 0m, null },
                    { 20, null, 20, 0m, null },
                    { 21, null, 21, 0m, null },
                    { 22, null, 22, 0m, null },
                    { 23, null, 23, 0m, null },
                    { 24, null, 24, 0m, null },
                    { 25, null, 25, 0m, null },
                    { 26, null, 26, 0m, null },
                    { 27, null, 27, 0m, null },
                    { 28, null, 28, 0m, null },
                    { 29, null, 29, 0m, null },
                    { 30, null, 30, 0m, null },
                    { 31, null, 31, 0m, null },
                    { 32, null, 32, 0m, null },
                    { 33, null, 33, 0m, null },
                    { 34, null, 34, 0m, null },
                    { 35, null, 35, 0m, null },
                    { 36, null, 36, 0m, null },
                    { 37, null, 37, 0m, null },
                    { 38, null, 38, 0m, null },
                    { 39, null, 39, 0m, null },
                    { 40, null, 40, 0m, null },
                    { 41, null, 41, 0m, null },
                    { 42, null, 42, 0m, null },
                    { 43, null, 43, 0m, null },
                    { 44, null, 44, 0m, null },
                    { 45, null, 45, 0m, null },
                    { 46, null, 46, 0m, null },
                    { 47, null, 47, 0m, null },
                    { 48, null, 48, 0m, null },
                    { 49, null, 49, 0m, null },
                    { 50, null, 50, 0m, null },
                    { 51, null, 51, 0m, null },
                    { 52, null, 52, 0m, null },
                    { 53, null, 53, 0m, null },
                    { 54, null, 54, 0m, null },
                    { 55, null, 55, 0m, null },
                    { 56, null, 56, 0m, null },
                    { 57, null, 57, 0m, null },
                    { 58, null, 58, 0m, null },
                    { 59, null, 59, 0m, null },
                    { 60, null, 60, 0m, null },
                    { 61, null, 61, 0m, null },
                    { 62, null, 62, 0m, null },
                    { 63, null, 63, 0m, null },
                    { 64, null, 64, 0m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_PortSlotId",
                table: "Vessels",
                column: "PortSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectedVessels");

            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.DropTable(
                name: "Ports");
        }
    }
}
