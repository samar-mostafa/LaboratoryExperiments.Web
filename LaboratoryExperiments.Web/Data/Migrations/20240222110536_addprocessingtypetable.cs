using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratoryExperiments.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addprocessingtypetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessingType",
                table: "Stations",
                newName: "ProcessingTypeId");

            migrationBuilder.CreateTable(
                name: "ProcessingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_ProcessingTypeId",
                table: "Stations",
                column: "ProcessingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTypes_Name",
                table: "ProcessingTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_ProcessingTypes_ProcessingTypeId",
                table: "Stations",
                column: "ProcessingTypeId",
                principalTable: "ProcessingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_ProcessingTypes_ProcessingTypeId",
                table: "Stations");

            migrationBuilder.DropTable(
                name: "ProcessingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Stations_ProcessingTypeId",
                table: "Stations");

            migrationBuilder.RenameColumn(
                name: "ProcessingTypeId",
                table: "Stations",
                newName: "ProcessingType");
        }
    }
}
