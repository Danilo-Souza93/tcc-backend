using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class sale_product_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    produto_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    produto_guid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venda_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    status = table.Column<string>(type: "text", nullable: false),
                    valor_total = table.Column<float>(type: "real", nullable: false),
                    endereco_rua = table.Column<string>(type: "text", nullable: false),
                    endereco_numero = table.Column<int>(type: "integer", nullable: false),
                    endereco_bairro = table.Column<string>(type: "text", nullable: false),
                    endereco_cidade = table.Column<string>(type: "text", nullable: false),
                    endereco_estado = table.Column<string>(type: "text", nullable: false),
                    endereco_cep = table.Column<string>(type: "text", nullable: false),
                    pessoal_cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    pessoal_nome = table.Column<string>(type: "text", nullable: false),
                    pessoal_sobrenome = table.Column<string>(type: "text", nullable: false),
                    cartao_numero = table.Column<string>(type: "text", nullable: false),
                    cartao_nome = table.Column<string>(type: "text", nullable: false),
                    cartao_bandeira = table.Column<string>(type: "text", nullable: false),
                    cartao_tipo = table.Column<string>(type: "text", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "venda_produto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venda_id = table.Column<Guid>(type: "uuid", nullable: false),
                    produto_id = table.Column<int>(type: "integer", nullable: false),
                    venda_produto_quantidade = table.Column<int>(type: "integer", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venda_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_venda_produto_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "produto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_venda_produto_vendas_venda_id",
                        column: x => x.venda_id,
                        principalTable: "vendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venda_produto_produto_id",
                table: "venda_produto",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_venda_produto_venda_id",
                table: "venda_produto",
                column: "venda_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venda_produto");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "vendas");
        }
    }
}
