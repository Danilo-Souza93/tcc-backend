using tcc.EntityModels;
using tcc.Models;

namespace tcc.Services.ProdutoService
{
    public interface IProdutoService
    {
        void CriarProdutos(List<ProdutoModel> produtos);
        List<ProdutoModel> GetProductList();
        List<ProdutoEntityModel> GetProductByProductSaledId(List<ProdutosVendidos> produtosVendidos);
        ProdutoModel UpdateProduto(ProdutoModel produto);
    }
}
