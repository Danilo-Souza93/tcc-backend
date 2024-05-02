using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using tcc.EntityModels;
using tcc.Models;

namespace tcc.Context.Mapping
{
    public class VendaProdutoIMapping : IEntityTypeConfiguration<VendaProdutosEntityModel>
    {
        public void Configure(EntityTypeBuilder<VendaProdutosEntityModel> builder)
        {
            //Define nome da Tabela
            builder.ToTable("venda_produto");

            //Configura chave Primaria
            builder.Property(v => v.VendaProdutosId)
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd();

            //Configura chave Estrangeira de Venda
            builder.HasOne(v => v.Venda)
                .WithOne()
                .HasForeignKey<VendaEntityModel>(e => e.VendaId)
                .IsRequired();
            
            //Configura relação 1:n 
            builder.HasOne(v => v.ListProdutos)
                .WithMany()
                .HasForeignKey(e => e.VendaProdutosId)
                .IsRequired();

            // Mapeia a lista de produtos para uma coluna JSON
            builder.Property(e => e.ListProdutos)
                   .IsRequired()
                   .HasColumnType("jsonb") // Use jsonb para melhor desempenho e indexação
                   .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<List<ProdutosVendidos>>(v) ?? new List<ProdutosVendidos>()
                    ); // Serializa a lista de produtos para JSON
        }
    }
}
