using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tcc.EntityModels;
using tcc.Models;

namespace tcc.Context.Mapping
{
    public class ProdutoModelMapping: IEntityTypeConfiguration<ProdutoEntityModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntityModel> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uuid).HasDefaultValueSql("gen_random_uuid()");


            builder.Property(x => x.Nome).
                HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnName("valor")
                .IsRequired();

            builder.Property(x => x.dt_lote)
                .HasColumnName("dt_lote").
                IsRequired();

        }

    }
}
