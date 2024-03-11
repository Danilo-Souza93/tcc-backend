using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosPessoaisModel",
                columns: table => new
                {
                    Cpf = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Sobrenome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoaisModel", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroCartao = table.Column<int>(type: "integer", nullable: false),
                    CodigoSeguranca = table.Column<int>(type: "integer", nullable: false),
                    DtValidade = table.Column<string>(type: "text", nullable: false),
                    NomeCartao = table.Column<string>(type: "text", nullable: false),
                    Bandeira = table.Column<string>(type: "text", nullable: false),
                    DadosPagamentoModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosPagamentoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DebitoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPagamentoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosPagamentoModel_Cartao_DebitoId",
                        column: x => x.DebitoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ValorTotal = table.Column<float>(type: "real", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false),
                    DadosPessoaisCpf = table.Column<int>(type: "integer", nullable: false),
                    DadosPagamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendas_DadosPagamentoModel_DadosPagamentoId",
                        column: x => x.DadosPagamentoId,
                        principalTable: "DadosPagamentoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendas_DadosPessoaisModel_DadosPessoaisCpf",
                        column: x => x.DadosPessoaisCpf,
                        principalTable: "DadosPessoaisModel",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendas_EnderecoModel_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "EnderecoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Detalhe = table.Column<string>(type: "text", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    VendaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produtos_vendas_VendaModelId",
                        column: x => x.VendaModelId,
                        principalTable: "vendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_DadosPagamentoModelId",
                table: "Cartao",
                column: "DadosPagamentoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosPagamentoModel_DebitoId",
                table: "DadosPagamentoModel",
                column: "DebitoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_VendaModelId",
                table: "produtos",
                column: "VendaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_DadosPagamentoId",
                table: "vendas",
                column: "DadosPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_DadosPessoaisCpf",
                table: "vendas",
                column: "DadosPessoaisCpf");

            migrationBuilder.CreateIndex(
                name: "IX_vendas_EnderecoId",
                table: "vendas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_DadosPagamentoModel_DadosPagamentoModelId",
                table: "Cartao",
                column: "DadosPagamentoModelId",
                principalTable: "DadosPagamentoModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_DadosPagamentoModel_DadosPagamentoModelId",
                table: "Cartao");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "vendas");

            migrationBuilder.DropTable(
                name: "DadosPessoaisModel");

            migrationBuilder.DropTable(
                name: "EnderecoModel");

            migrationBuilder.DropTable(
                name: "DadosPagamentoModel");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
