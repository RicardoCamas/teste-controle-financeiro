using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Descricao = table.Column<string>(maxLength: 300, nullable: true),
                    Conta = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento");
        }
    }
}
