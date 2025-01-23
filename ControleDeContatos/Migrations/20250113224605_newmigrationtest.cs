using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class newmigrationtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observacoes_Contatos_ContatoId",
                table: "Observacoes");

            migrationBuilder.DropIndex(
                name: "IX_Observacoes_ContatoId",
                table: "Observacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_ContatoId",
                table: "Observacoes",
                column: "ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observacoes_Contatos_ContatoId",
                table: "Observacoes",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
