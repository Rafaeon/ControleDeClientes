using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarObservacoes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObservacaoModel_Contatos_ContatoId",
                table: "ObservacaoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObservacaoModel",
                table: "ObservacaoModel");

            migrationBuilder.RenameTable(
                name: "ObservacaoModel",
                newName: "Observacoes");

            migrationBuilder.RenameIndex(
                name: "IX_ObservacaoModel_ContatoId",
                table: "Observacoes",
                newName: "IX_Observacoes_ContatoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Observacoes",
                table: "Observacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observacoes_Contatos_ContatoId",
                table: "Observacoes",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observacoes_Contatos_ContatoId",
                table: "Observacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Observacoes",
                table: "Observacoes");

            migrationBuilder.RenameTable(
                name: "Observacoes",
                newName: "ObservacaoModel");

            migrationBuilder.RenameIndex(
                name: "IX_Observacoes_ContatoId",
                table: "ObservacaoModel",
                newName: "IX_ObservacaoModel_ContatoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObservacaoModel",
                table: "ObservacaoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObservacaoModel_Contatos_ContatoId",
                table: "ObservacaoModel",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
