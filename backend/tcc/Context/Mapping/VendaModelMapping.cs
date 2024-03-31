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
        builder.HasMany(v => v.Produto)
            .WithOne()
            .HasForeignKey(v => v.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Especifica o comportamento de exclusão em cascata  


        // Configura a relação com EnderecoModel
        builder.OwnsOne(v => v.Endereco, endereco =>
        {
            endereco.Property(e => e.EnderecoId)
                .IsRequired()
                .HasColumnName("endereco_id");

            endereco.Property(e => e.Cep)
                .IsRequired()
                .HasColumnName("endereco_cep");

            endereco.Property(e => e.Numero)
                .IsRequired()
                .HasColumnName("endereco_num");
        });


        // Configura a relação com DadosPessoaisModel
        builder.OwnsOne(v => v.DadosPessoais, dadosPessoais =>
        {
            dadosPessoais.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("cpf");
        });

        // Configura a relação com DadosPagamentoModel
        builder.OwnsOne(v => v.DadosPagamento, dadosPagamento =>
        {
            dadosPagamento.Property(e => e.DadosPagamentoId)
                .IsRequired()
                .HasColumnName("pagamentoId");
        });
               
    }
}
