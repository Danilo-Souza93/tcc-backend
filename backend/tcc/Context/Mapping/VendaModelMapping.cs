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
        builder.Property(v => v.VendaId)
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired();

        // Configura a propriedade Status
        builder.Property(v => v.Status)
               .HasColumnName("status")
               .IsRequired();

        // Configura a propriedade ValorTotal
        builder.Property(v => v.ValorTotal)
               .HasColumnName("valor_total")
               .IsRequired();
        
        // Configura a relação 1:1
        builder.HasOne(v => v.VendaProduto)
            .WithOne()
            .HasForeignKey<VendaProdutosEntityModel>(e => e.VendaProdutosId)
            .IsRequired();

        // Configura a relação com EnderecoModel
        builder.OwnsOne(v => v.Endereco, endereco =>
        {
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
            dadosPagamento.OwnsOne(j => j.Cartao, cartao =>
            {
                cartao.Property(i => i.NumeroCartao)
                    .IsRequired();

                cartao.Property(i => i.NomeCartao)
                    .IsRequired();

                cartao.Property(i => i.Tipo)
                    .IsRequired();
            });
        });
    }
}
