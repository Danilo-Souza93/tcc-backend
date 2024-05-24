namespace tcc.Models
{
    public class ProdutosVendidos
    {
        public int ProdutoId { get; set; }
        public int Quantidade {  get; set; }

        public ProdutosVendidos(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
