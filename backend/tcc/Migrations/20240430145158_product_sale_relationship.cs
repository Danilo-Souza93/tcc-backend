using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class product_sale_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoModel");

            migrationBuilder.AddColumn<int>(
                name: "VendaEntityModelId",
                table: "produtos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "produto_guid",
                table: "produtos",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_VendaEntityModelId",
                table: "produtos",
                column: "VendaEntityModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_vendas_VendaEntityModelId",
                table: "produtos",
                column: "VendaEntityModelId",
                principalTable: "vendas",
                principalColumn: "venda_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_vendas_VendaEntityModelId",
                table: "produtos");

            migrationBuilder.DropIndex(
                name: "IX_produtos_VendaEntityModelId",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "VendaEntityModelId",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "produto_guid",
                table: "produtos");

            migrationBuilder.CreateTable(
                name: "ProdutoModel",
                columns: table => new
                {
                    VendaEntityModelId = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Detalhe = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    product_lote = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoModel", x => new { x.VendaEntityModelId, x.product_id });
                    table.ForeignKey(
                        name: "FK_ProdutoModel_vendas_VendaEntityModelId",
                        column: x => x.VendaEntityModelId,
                        principalTable: "vendas",
                        principalColumn: "venda_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
