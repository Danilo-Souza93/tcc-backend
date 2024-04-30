using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class entity_name_correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadosPagamento_Credito_Bandeira",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "DadosPagamento_Credito_CodigoSeguranca",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "DadosPagamento_Credito_NomeCartao",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "cred_card_id",
                table: "vendas");

            migrationBuilder.DropColumn(
                name: "credt_card_name",
                table: "vendas");

            migrationBuilder.RenameColumn(
                name: "Endereco_Rua",
                table: "vendas",
                newName: "endereco_rua");

            migrationBuilder.RenameColumn(
                name: "Endereco_Estado",
                table: "vendas",
                newName: "endereco_estado");

            migrationBuilder.RenameColumn(
                name: "Endereco_Cidade",
                table: "vendas",
                newName: "endereco_cidade");

            migrationBuilder.RenameColumn(
                name: "Endereco_Bairro",
                table: "vendas",
                newName: "endereco_bairro");

            migrationBuilder.RenameColumn(
                name: "endereco_num",
                table: "vendas",
                newName: "endereco_numero");

            migrationBuilder.RenameColumn(
                name: "debt_card_validity",
                table: "vendas",
                newName: "cartao_dt_validade");

            migrationBuilder.RenameColumn(
                name: "debt_card_name",
                table: "vendas",
                newName: "cartao_numero");

            migrationBuilder.RenameColumn(
                name: "debt_card_id",
                table: "vendas",
                newName: "cartao_id");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "vendas",
                newName: "pessoal_cpf");

            migrationBuilder.RenameColumn(
                name: "DadosPessoais_Sobrenome",
                table: "vendas",
                newName: "pessoal_sobrenome");

            migrationBuilder.RenameColumn(
                name: "DadosPessoais_Nome",
                table: "vendas",
                newName: "pessoal_nome");

            migrationBuilder.RenameColumn(
                name: "DadosPagamento_Debito_NomeCartao",
                table: "vendas",
                newName: "cartao_nome");

            migrationBuilder.RenameColumn(
                name: "DadosPagamento_Debito_CodigoSeguranca",
                table: "vendas",
                newName: "cartao_codigo_seguranca");

            migrationBuilder.RenameColumn(
                name: "DadosPagamento_Debito_Bandeira",
                table: "vendas",
                newName: "cartao_bandeira");

            migrationBuilder.RenameColumn(
                name: "credt_card_validity",
                table: "vendas",
                newName: "cartao_tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "endereco_rua",
                table: "vendas",
                newName: "Endereco_Rua");

            migrationBuilder.RenameColumn(
                name: "endereco_estado",
                table: "vendas",
                newName: "Endereco_Estado");

            migrationBuilder.RenameColumn(
                name: "endereco_cidade",
                table: "vendas",
                newName: "Endereco_Cidade");

            migrationBuilder.RenameColumn(
                name: "endereco_bairro",
                table: "vendas",
                newName: "Endereco_Bairro");

            migrationBuilder.RenameColumn(
                name: "pessoal_sobrenome",
                table: "vendas",
                newName: "DadosPessoais_Sobrenome");

            migrationBuilder.RenameColumn(
                name: "pessoal_nome",
                table: "vendas",
                newName: "DadosPessoais_Nome");

            migrationBuilder.RenameColumn(
                name: "pessoal_cpf",
                table: "vendas",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "endereco_numero",
                table: "vendas",
                newName: "endereco_num");

            migrationBuilder.RenameColumn(
                name: "cartao_numero",
                table: "vendas",
                newName: "debt_card_name");

            migrationBuilder.RenameColumn(
                name: "cartao_nome",
                table: "vendas",
                newName: "DadosPagamento_Debito_NomeCartao");

            migrationBuilder.RenameColumn(
                name: "cartao_id",
                table: "vendas",
                newName: "debt_card_id");

            migrationBuilder.RenameColumn(
                name: "cartao_dt_validade",
                table: "vendas",
                newName: "debt_card_validity");

            migrationBuilder.RenameColumn(
                name: "cartao_codigo_seguranca",
                table: "vendas",
                newName: "DadosPagamento_Debito_CodigoSeguranca");

            migrationBuilder.RenameColumn(
                name: "cartao_bandeira",
                table: "vendas",
                newName: "DadosPagamento_Debito_Bandeira");

            migrationBuilder.RenameColumn(
                name: "cartao_tipo",
                table: "vendas",
                newName: "credt_card_validity");

            migrationBuilder.AddColumn<string>(
                name: "DadosPagamento_Credito_Bandeira",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DadosPagamento_Credito_CodigoSeguranca",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DadosPagamento_Credito_NomeCartao",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "cred_card_id",
                table: "vendas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "credt_card_name",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
