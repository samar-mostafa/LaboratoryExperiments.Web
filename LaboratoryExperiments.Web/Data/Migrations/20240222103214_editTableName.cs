using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratoryExperiments.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class editTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTypes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Stations");

            migrationBuilder.AddColumn<int>(
                name: "StationStatusId",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExperimentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_StationStatusId",
                table: "Stations",
                column: "StationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_StationStatuses_StationStatusId",
                table: "Stations",
                column: "StationStatusId",
                principalTable: "StationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_StationStatuses_StationStatusId",
                table: "Stations");

            migrationBuilder.DropTable(
                name: "ExperimentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Stations_StationStatusId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "StationStatusId",
                table: "Stations");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Stations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypes", x => x.Id);
                });
        }
    }
}
