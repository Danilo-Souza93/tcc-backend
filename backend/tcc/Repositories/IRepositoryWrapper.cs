using tcc.Repositories.ProdutoRepository;
using tcc.Repositories.VendasProdutoRepository;
using tcc.Repositories.VendasRepository;

namespace tcc.Repositories
{
    public interface IRepositoryWrapper
    {
        IProdutoRepository ProdutoRepository { get; }
        IVendaRepository VendaRepository { get; }
        IVendaProdutoRepository VendaProdutoRepository { get; }
        void Save();
    }
}
