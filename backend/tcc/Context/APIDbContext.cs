using Microsoft.EntityFrameworkCore;
using tcc.Context.Mapping;
using tcc.EntityModels;
using tcc.Models;

namespace tcc.Context
{
    public class APIDbContext :  DbContext
    {
        public DbSet<VendaEntityModel> Vendas { get; set; }
        public DbSet<ProdutoEntityModel> Produtos { get; set; }
        public DbSet<VendaProdutosEntityModel> VendaProdutos { get; set; }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendaModelMapping());
            modelBuilder.ApplyConfiguration(new ProdutoModelMapping());
            modelBuilder.ApplyConfiguration(new VendaProdutoIMapping());
        }
    }
}
