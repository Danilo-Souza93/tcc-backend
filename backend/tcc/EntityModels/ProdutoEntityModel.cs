namespace tcc.EntityModels
{
    public class ProdutoEntityModel: EntityBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int QuantidadeEstoque { get; set; }
        public float Valor { get; set; }
    }
}
