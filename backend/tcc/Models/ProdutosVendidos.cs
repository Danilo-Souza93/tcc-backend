namespace tcc.Models
{
    public class ProdutosVendidos
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade {  get; set; }

        ProdutosVendidos()
        {
            ProdutoId = Guid.NewGuid();
            Quantidade = 0;
        }
    }
}
