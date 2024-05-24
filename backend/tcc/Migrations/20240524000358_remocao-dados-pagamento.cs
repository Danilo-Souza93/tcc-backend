using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class remocaodadospagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cartao_bandeira",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "cartao_nome",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "cartao_numero",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "cartao_tipo",
                table: "vendas");

            migrationBuilder.AddColumn<string>(
                name: "status_pagamento",
                table: "vendas",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<float>(
                name: "valor",
                table: "produtos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status_pagamento",
                table: "vendas");

            migrationBuilder.AddColumn<string>(
                name: "cartao_bandeira",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cartao_nome",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cartao_numero",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cartao_tipo",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "produtos",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
