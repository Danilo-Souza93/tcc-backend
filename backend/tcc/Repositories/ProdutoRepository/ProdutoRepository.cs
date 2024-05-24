using tcc.Context;
using tcc.EntityModels;

namespace tcc.Repositories.ProdutoRepository
{
    public class ProdutoRepositoy : RepositoryBase<ProdutoEntityModel>, IProdutoRepository
    {
        public ProdutoRepositoy(APIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
