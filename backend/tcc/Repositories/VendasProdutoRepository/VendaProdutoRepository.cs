using tcc.Context;
using tcc.EntityModels;

namespace tcc.Repositories.VendasProdutoRepository
{
    public class VendaProdutoRepository: RepositoryBase<VendaProdutosEntityModel>, IVendaProdutoRepository
    {
        public VendaProdutoRepository(APIDbContext context) : base(context) { }
    }
}
