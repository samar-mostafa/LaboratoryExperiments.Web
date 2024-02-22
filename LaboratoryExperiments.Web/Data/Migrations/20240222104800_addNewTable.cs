using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratoryExperiments.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SanitaryDrainId",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SanitaryDrain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitaryDrain", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_SanitaryDrainId",
                table: "Stations",
                column: "SanitaryDrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_SanitaryDrain_SanitaryDrainId",
                table: "Stations",
                column: "SanitaryDrainId",
                principalTable: "SanitaryDrain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_SanitaryDrain_SanitaryDrainId",
                table: "Stations");

            migrationBuilder.DropTable(
                name: "SanitaryDrain");

            migrationBuilder.DropIndex(
                name: "IX_Stations_SanitaryDrainId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "SanitaryDrainId",
                table: "Stations");
        }
    }
}
