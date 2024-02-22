using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratoryExperiments.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class editTablesAndAddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_EffleuntExperiments_EffleuntExperimentId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_InffleuntExperiments_InffleuntExperimentId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "EffleuntExperiments");

            migrationBuilder.DropTable(
                name: "InffleuntExperiments");

            migrationBuilder.DropIndex(
                name: "IX_Tests_EffleuntExperimentId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "EffleuntExperimentId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "InffleuntExperimentId",
                table: "Tests",
                newName: "ExperimentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_InffleuntExperimentId",
                table: "Tests",
                newName: "IX_Tests_ExperimentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "In_Eff",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProcessingSystems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Experiments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EffleuntValue",
                table: "Experiments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InffleuntValue",
                table: "Experiments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Branches",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Name",
                table: "Units",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_Name",
                table: "Stations",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingSystems_Name",
                table: "ProcessingSystems",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_Name",
                table: "Experiments",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                table: "Branches",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Experiments_ExperimentId",
                table: "Tests",
                column: "ExperimentId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Experiments_ExperimentId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Units_Name",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Stations_Name",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingSystems_Name",
                table: "ProcessingSystems");

            migrationBuilder.DropIndex(
                name: "IX_Experiments_Name",
                table: "Experiments");

            migrationBuilder.DropIndex(
                name: "IX_Branches_Name",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "In_Eff",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "EffleuntValue",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "InffleuntValue",
                table: "Experiments");

            migrationBuilder.RenameColumn(
                name: "ExperimentId",
                table: "Tests",
                newName: "InffleuntExperimentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_ExperimentId",
                table: "Tests",
                newName: "IX_Tests_InffleuntExperimentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EffleuntExperimentId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProcessingSystems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Experiments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EffleuntExperiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffleuntExperiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EffleuntExperiments_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InffleuntExperiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InffleuntExperiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InffleuntExperiments_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_EffleuntExperimentId",
                table: "Tests",
                column: "EffleuntExperimentId");

            migrationBuilder.CreateIndex(
                name: "IX_EffleuntExperiments_ExperimentId",
                table: "EffleuntExperiments",
                column: "ExperimentId");

            migrationBuilder.CreateIndex(
                name: "IX_InffleuntExperiments_ExperimentId",
                table: "InffleuntExperiments",
                column: "ExperimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_EffleuntExperiments_EffleuntExperimentId",
                table: "Tests",
                column: "EffleuntExperimentId",
                principalTable: "EffleuntExperiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_InffleuntExperiments_InffleuntExperimentId",
                table: "Tests",
                column: "InffleuntExperimentId",
                principalTable: "InffleuntExperiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
