using Microsoft.EntityFrameworkCore;
using tcc.Models;

namespace tcc.Context
{
    public class APIDbContext :  DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<VendaModel> vendas { get; set; }
        public DbSet<ProdutoModel> produtos { get; set; }
    }
}
