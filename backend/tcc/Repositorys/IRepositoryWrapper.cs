using tcc.Repositorys.ProdutoRepository;

namespace tcc.Repositorys
{
    public interface IRepositoryWrapper
    {
        IProdutoRepository ProdutoRepository { get; }
        void Save();
    }
}
