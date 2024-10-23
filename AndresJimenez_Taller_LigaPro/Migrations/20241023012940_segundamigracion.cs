using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndresJimenez_Taller_LigaPro.Migrations
{
    /// <inheritdoc />
    public partial class segundamigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEquipo",
                table: "Estadio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estadio_IdEquipo",
                table: "Estadio",
                column: "IdEquipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Estadio_Equipo_IdEquipo",
                table: "Estadio",
                column: "IdEquipo",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estadio_Equipo_IdEquipo",
                table: "Estadio");

            migrationBuilder.DropIndex(
                name: "IX_Estadio_IdEquipo",
                table: "Estadio");

            migrationBuilder.DropColumn(
                name: "IdEquipo",
                table: "Estadio");
        }
    }
}
