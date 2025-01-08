using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoObservacaoContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Observacao",
                table: "Observacao");

            migrationBuilder.RenameTable(
                name: "Observacao",
                newName: "Observacoes");

            migrationBuilder.AddColumn<int>(
                name: "ContatoId",
                table: "Observacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Observacoes",
                table: "Observacoes",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observacoes_Contatos_ContatoId",
                table: "Observacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Observacoes",
                table: "Observacoes");

            migrationBuilder.DropIndex(
                name: "IX_Observacoes_ContatoId",
                table: "Observacoes");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "Observacoes");

            migrationBuilder.RenameTable(
                name: "Observacoes",
                newName: "Observacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Observacao",
                table: "Observacao",
                column: "Id");
        }
    }
}
