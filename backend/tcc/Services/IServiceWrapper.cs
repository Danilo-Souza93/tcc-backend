using tcc.Services.ProdutoService;
using tcc.Services.VendasService;
using tcc.Strategies;

namespace tcc.Services
{
    public interface IServiceWrapper
    {
        IProdutoService ProdutoService { get; }
        IVendaService VendaService { get; }
        IStrategy Strategy { get; }
    }
}
