using Microsoft.EntityFrameworkCore;
using tcc.Context.Mapping;
using tcc.Models;

namespace tcc.Context
{
    public class APIDbContext :  DbContext
    {
        public DbSet<VendaModel> Vendas { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendaModelMapping());
            modelBuilder.ApplyConfiguration(new ProdutoModelMapping());
        }
    }
}
