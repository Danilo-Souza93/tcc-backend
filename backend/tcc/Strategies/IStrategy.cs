using tcc.EntityModels;
using tcc.Models;

namespace tcc.Strategies
{
    public interface IStrategy
    {
        List<ProdutoEntityModel> ValidacaoVenda(VendaModel venda);
    }
}
