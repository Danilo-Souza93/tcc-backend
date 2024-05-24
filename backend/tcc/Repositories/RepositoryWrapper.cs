using tcc.Context;
using tcc.Repositories.ProdutoRepository;
using tcc.Repositories.VendasProdutoRepository;
using tcc.Repositories.VendasRepository;


namespace tcc.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private APIDbContext _dbcontext;
        private readonly Lazy<IProdutoRepository> _produtoRepository;
        private readonly Lazy<IVendaRepository> _vendaRepository;
        private readonly Lazy<IVendaProdutoRepository> _vendaProdutoRepository;

        public RepositoryWrapper(APIDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _produtoRepository = new Lazy<IProdutoRepository>(() => new ProdutoRepositoy(dbcontext));
            _vendaRepository = new Lazy<IVendaRepository>(() => new VendaRepository(dbcontext));
            _vendaProdutoRepository = new Lazy<IVendaProdutoRepository>(() => new VendaProdutoRepository(dbcontext));
        }

        public IProdutoRepository ProdutoRepository => _produtoRepository.Value;
        public IVendaRepository VendaRepository => _vendaRepository.Value;
        public IVendaProdutoRepository VendaProdutoRepository => _vendaProdutoRepository.Value;

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
