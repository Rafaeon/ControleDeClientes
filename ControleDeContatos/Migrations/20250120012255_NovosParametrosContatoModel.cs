using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class NovosParametrosContatoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeGarantia",
                table: "Contatos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeGarantia",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Contatos");
        }
    }
}
