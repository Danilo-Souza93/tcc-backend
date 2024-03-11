using tcc.Context;
using tcc.Repositorys.ProdutoRepository;

namespace tcc.Repositorys
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private APIDbContext _dbcontext;
        private readonly Lazy<IProdutoRepository> _produtoRepository;

        public RepositoryWrapper(APIDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _produtoRepository = new Lazy<IProdutoRepository>(() => new ProdutoRepositoy(dbcontext));
        }

        public IProdutoRepository ProdutoRepository => _produtoRepository.Value;

        void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
