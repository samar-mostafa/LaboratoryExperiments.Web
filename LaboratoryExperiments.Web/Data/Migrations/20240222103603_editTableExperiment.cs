using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratoryExperiments.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class editTableExperiment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperimentTypeId",
                table: "Experiments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_ExperimentTypeId",
                table: "Experiments",
                column: "ExperimentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiments_ExperimentTypes_ExperimentTypeId",
                table: "Experiments",
                column: "ExperimentTypeId",
                principalTable: "ExperimentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiments_ExperimentTypes_ExperimentTypeId",
                table: "Experiments");

            migrationBuilder.DropIndex(
                name: "IX_Experiments_ExperimentTypeId",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "ExperimentTypeId",
                table: "Experiments");
        }
    }
}
