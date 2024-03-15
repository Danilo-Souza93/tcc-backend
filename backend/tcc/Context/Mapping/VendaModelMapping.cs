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

        // Configura a relação com EnderecoModel
        builder.HasOne(v => v.Endereco)
               .WithMany()
               .HasForeignKey(v => v.EnderecoId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); // Especifica o comportamento de exclusão em cascata

        // Configura a relação com Produtos (relacionamento muitos para muitos)
        builder.HasMany(v => v.Produtos)
               .WithMany()
               .UsingEntity<Dictionary<string, object>>(
                    "venda_produto",
                    j => j.HasOne<ProdutoModel>()
                        .WithMany()
                        .HasForeignKey("ProdutoId"),

                    j => j.HasOne<VendaEntityModel>()
                        .WithMany()
                        .HasForeignKey("VendaId")
                );
                                  

        // Configura a relação com DadosPessoaisModel
        builder.HasOne(v => v.DadosPessoais)
               .WithMany()
               .HasForeignKey(v => v.DadosPessoaisId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); // Especifica o comportamento de exclusão em cascata

        // Configura a relação com DadosPagamentoModel
        builder.HasOne(v => v.DadosPagamento)
               .WithMany()
               .HasForeignKey(v => v.DadosPagamentoId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); // Especifica o comportamento de exclusão em cascata
    }
}
