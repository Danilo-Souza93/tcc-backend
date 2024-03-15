using Microsoft.EntityFrameworkCore.Storage;
using tcc.Context;
using tcc.EntityModels;
using tcc.Models;

namespace tcc.Repositorys.ProdutoRepository
{
    public class ProdutoRepositoy : RepositoryBase<ProdutoEntityModel>, IProdutoRepository
    {
        public ProdutoRepositoy(APIDbContext dbContext) : base(dbContext) 
        {
        }
    }
}
