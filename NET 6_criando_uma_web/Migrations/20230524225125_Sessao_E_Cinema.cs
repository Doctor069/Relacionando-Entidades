using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_6_Relacionando_Entidades.Migrations
{
    /// <inheritdoc />
    public partial class Sessao_E_Cinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaID",
                table: "Sessoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_CinemaID",
                table: "Sessoes",
                column: "CinemaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaID",
                table: "Sessoes",
                column: "CinemaID",
                principalTable: "Cinemas",
                principalColumn: "IdCinema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaID",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_CinemaID",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "CinemaID",
                table: "Sessoes");
        }
    }
}
