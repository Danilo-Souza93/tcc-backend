using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroCartao = table.Column<string>(type: "text", nullable: false),
                    CodigoSeguranca = table.Column<string>(type: "text", nullable: false),
                    DtValidade = table.Column<string>(type: "text", nullable: false),
                    NomeCartao = table.Column<string>(type: "text", nullable: false),
                    Bandeira = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    produto_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    detalhe = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    dt_lote = table.Column<string>(type: "text", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.produto_id);
                });

            migrationBuilder.CreateTable(
                name: "vendas",
                columns: table => new
                {
                    venda_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: false),
                    valor_total = table.Column<float>(type: "real", nullable: false),
                    endereco_id = table.Column<int>(type: "integer", nullable: false),
                    Endereco_Rua = table.Column<string>(type: "text", nullable: false),
                    endereco_num = table.Column<int>(type: "integer", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "text", nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "text", nullable: false),
                    Endereco_Estado = table.Column<string>(type: "text", nullable: false),
                    endereco_cep = table.Column<int>(type: "integer", nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DadosPessoais_Nome = table.Column<string>(type: "text", nullable: false),
                    DadosPessoais_Sobrenome = table.Column<string>(type: "text", nullable: false),
                    pagamentoId = table.Column<int>(type: "integer", nullable: false),
                    DadosPagamento_DebitoId = table.Column<int>(type: "integer", nullable: false),
                    DadosPagamento_CreditoId = table.Column<int>(type: "integer", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_venda_id", x => x.venda_id);
                    table.ForeignKey(
                        name: "FK_vendas_Cartao_DadosPagamento_CreditoId",
                        column: x => x.DadosPagamento_CreditoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendas_Cartao_DadosPagamento_DebitoId",
                        column: x => x.DadosPagamento_DebitoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Detalhe = table.Column<string>(type: "text", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    dt_lote = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoModel_vendas_Id",
                        column: x => x.Id,
                        principalTable: "vendas",
                        principalColumn: "venda_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vendas_DadosPagamento_CreditoId",
                table: "vendas",
                column: "DadosPagamento_CreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_DadosPagamento_DebitoId",
                table: "vendas",
                column: "DadosPagamento_DebitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoModel");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "vendas");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
