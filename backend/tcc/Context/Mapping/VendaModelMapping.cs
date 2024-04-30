using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using tcc.EntityModels;
using tcc.Models;

public class VendaModelMapping : IEntityTypeConfiguration<VendaEntityModel>
{
	public void Configure(EntityTypeBuilder<VendaEntityModel> builder)
	{
        // Define o nome da tabela
        builder.ToTable("vendas");

        // Configura a chave primária
        builder.HasKey(v => v.Id).HasName("pk_venda_id");

        // Configura a propriedade Status
        builder.Property(v => v.Status)
               .HasColumnName("status")
               .IsRequired();

        // Configura a propriedade ValorTotal
        builder.Property(v => v.ValorTotal)
               .HasColumnName("valor_total")
               .IsRequired();

        // Configura a relação com ProdutoModel
        //builder.OwnsMany(v => v.Produto, produto =>
        //{
        //    produto.Property(e => e.Id)
        //     .IsRequired()
        //     .HasColumnName("product_id");

        //    produto.Property(e => e.dt_lote)
        //        .IsRequired()
        //        .HasColumnName("product_lote");
        //});

        // Configura a relação com EnderecoModel
        builder.OwnsOne(v => v.Endereco, endereco =>
        {
            endereco.Property(e => e.EnderecoId)
                .IsRequired();

            endereco.Property(e => e.Cep)
                .IsRequired();

            endereco.Property(e => e.Numero)
                .IsRequired();
        });


        // Configura a relação com DadosPessoaisModel
        builder.OwnsOne(v => v.DadosPessoais, dadosPessoais =>
        {
            dadosPessoais.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsRequired();
        });

        // Configura a relação com DadosPagamentoModel
        builder.OwnsOne(v => v.DadosPagamento, dadosPagamento =>
        {
            dadosPagamento.Property(e => e.DadosPagamentoId)
                .IsRequired()
                .HasColumnName("pagamento_id");

            dadosPagamento.OwnsOne(j => j.Cartao, cartao =>
            {
                cartao.Property(i => i.Id)
                    .IsRequired();

                cartao.Property(i => i.NumeroCartao)
                    .IsRequired();

                cartao.Property(i => i.DtValidade)
                    .IsRequired();
            });

            //dadosPagamento.OwnsOne(j => j.Debito, debito =>
            //{
            //    debito.Property(i => i.Id)
            //        .IsRequired()
            //        .HasColumnName("debt_card_id");

            //    debito.Property(i => i.NumeroCartao)
            //        .IsRequired()
            //        .HasColumnName("debt_card_name");

            //    debito.Property(i => i.DtValidade)
            //        .IsRequired()
            //        .HasColumnName("debt_card_validity");
            //});

            //dadosPagamento.OwnsOne(j => j.Credito, credito =>
            //{
            //    credito.Property(i => i.Id)
            //        .IsRequired()
            //        .HasColumnName("cred_card_id");

            //    credito.Property(i => i.NumeroCartao)
            //        .IsRequired()
            //        .HasColumnName("credt_card_name");

            //    credito.Property(i => i.DtValidade)
            //        .IsRequired()
            //        .HasColumnName("credt_card_validity");
            //});
        });

    }
}
