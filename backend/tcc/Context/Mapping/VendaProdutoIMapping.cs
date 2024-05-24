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
        }
    }
}
