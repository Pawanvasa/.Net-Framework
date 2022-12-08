using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotAss18_10_2022.Migrations
{
    public partial class FiveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientsDaigonised = table.Column<int>(type: "int", nullable: true),
                    NumberOperations = table.Column<int>(type: "int", nullable: true),
                    NumberOfInjections = table.Column<int>(type: "int", nullable: true),
                    NumberOfPatientsMonitored = table.Column<int>(type: "int", nullable: true),
                    NumberRoomsCleaned = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Contact", "Discriminator", "NumberOperations", "PatientsDaigonised", "StaffCategory", "StaffName" },
                values: new object[,]
                {
                    { 1, "84652", "Doctor", 4, 5, "Doctor", "Pawan" },
                    { 2, "7372", "Doctor", 3, 2, "Doctor", "Mohan" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Contact", "Discriminator", "NumberOfInjections", "NumberOfPatientsMonitored", "StaffCategory", "StaffName" },
                values: new object[,]
                {
                    { 3, "7453", "Nurse", 34, 4, "Nurse", "Rani" },
                    { 4, "7462", "Nurse", 5, 7, "Nurse", "Jammy" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Contact", "Discriminator", "NumberRoomsCleaned", "StaffCategory", "StaffName" },
                values: new object[,]
                {
                    { 5, "7453", "WardBoy", 5, "WardBoy", "Amar" },
                    { 6, "3464", "WardBoy", 8, "WardBoy", "Bam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
