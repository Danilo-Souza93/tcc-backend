namespace tcc.Models
{
    public class DetalheVendaModel
    {
        public VendaModel Venda { get; set; }
        public List<ProdutoModel> ProdutosList { get; set; }

        public DetalheVendaModel()
        {
            Venda = new VendaModel();
            ProdutosList = new List<ProdutoModel>();
        }
    }
}
