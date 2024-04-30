using AutoMapper;
using tcc.Repositorys;
using tcc.Services.ProdutoService;



namespace tcc.Services
{
    public class ServiceWrapper: IServiceWrapper
    {
        private readonly Lazy<IProdutoService> _produtoService;

        public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
        {
            _produtoService = new Lazy<IProdutoService>(() => new ProdutosService(repository, mapper));
        }

       public IProdutoService ProdutoService => _produtoService.Value;
    }

}
