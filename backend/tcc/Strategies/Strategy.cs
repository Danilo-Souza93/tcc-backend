using AutoMapper;
using tcc.EntityModels;
using tcc.Models;
using tcc.Services.ProdutoService;

namespace tcc.Strategies
{
    public class Strategy : IStrategy
    {
        private readonly IProdutoService _produtoService;
        public Strategy(IProdutoService produtoService) 
        {
            _produtoService = produtoService;
        }

        //remover itens do estoque.
        //conferir valor total da venda
        //validar pagamento
        public List<ProdutoEntityModel> ValidacaoVenda(VendaModel venda) 
        {
        // regras:
        // produtos comprados nao pode ser maior do que o estoque
            var produtos = _produtoService.GetProductByProductSaledId(venda.ProdutosVendidos);
            float valorTotal = 0;

            if (produtos != null)
            {
                foreach(var item in venda.ProdutosVendidos)
                {
                    var prod = produtos.FirstOrDefault(x => x.Id == item.ProdutoId);
                    if (prod != null)
                    {
                        valorTotal += prod.Valor * item.Quantidade;

                        //validar que o item precisa ser menor que a quantidade em estoque
                        prod.QuantidadeEstoque -= item.Quantidade;
                    }
                }       
            }

            if (venda.DadosPagamento != null) 
            { 
                //validar pagamento        
            }

            return produtos;
            
        }

    }
}
