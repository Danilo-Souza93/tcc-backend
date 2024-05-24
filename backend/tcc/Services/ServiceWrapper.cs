using AutoMapper;
using tcc.Repositories;
using tcc.Services.ProdutoService;
using tcc.Services.VendasService;
using tcc.Strategies;



namespace tcc.Services
{
    public class ServiceWrapper: IServiceWrapper
    {
        private readonly Lazy<IProdutoService> _produtoService;
        private readonly Lazy<IVendaService> _vendaService;
        private readonly Lazy<IStrategy> _strategy;

        public ServiceWrapper(
            IRepositoryWrapper repository, 
            IMapper mapper
            )
        {
            _produtoService = new Lazy<IProdutoService>(() => new ProdutosService(repository, mapper));
            _vendaService = new Lazy<IVendaService>(() => new VendaService(repository, mapper, Strategy));
            _strategy = new Lazy<IStrategy>(() => new Strategy(ProdutoService));
        }

       public IProdutoService ProdutoService => _produtoService.Value;
       public IVendaService VendaService => _vendaService.Value;
       public IStrategy Strategy => _strategy.Value;
    }

}
