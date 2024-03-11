using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tcc.Models;

namespace tcc.Context.Mapping
{
    public class ProdutoModelMapping: IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {

        }

    }
}
