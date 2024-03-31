using tcc.Services.ProdutoService;

namespace tcc.Services
{
    public interface IServiceWrapper
    {
        IProdutoService ProdutoService { get; }
    }
}
