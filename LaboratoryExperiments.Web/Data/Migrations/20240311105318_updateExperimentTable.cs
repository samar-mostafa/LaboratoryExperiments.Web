using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratoryExperiments.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateExperimentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "EffleuntValueTo",
                table: "Experiments",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "InffleuntValueTo",
                table: "Experiments",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffleuntValueTo",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "InffleuntValueTo",
                table: "Experiments");
        }
    }
}
