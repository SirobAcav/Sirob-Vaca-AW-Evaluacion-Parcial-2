using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenciasAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "conferencia_id",
                table: "Asistentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "conferencia_id1",
                table: "Asistentes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asistentes_conferencia_id1",
                table: "Asistentes",
                column: "conferencia_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistentes_Conferencias_conferencia_id1",
                table: "Asistentes",
                column: "conferencia_id1",
                principalTable: "Conferencias",
                principalColumn: "conferencia_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistentes_Conferencias_conferencia_id1",
                table: "Asistentes");

            migrationBuilder.DropIndex(
                name: "IX_Asistentes_conferencia_id1",
                table: "Asistentes");

            migrationBuilder.DropColumn(
                name: "conferencia_id",
                table: "Asistentes");

            migrationBuilder.DropColumn(
                name: "conferencia_id1",
                table: "Asistentes");
        }
    }
}
