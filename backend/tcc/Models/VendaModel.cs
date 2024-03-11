using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace tcc.Models
{
    public class VendaModel
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public float ValorTotal { get; set; }
        public EnderecoModel Endereco { get; set; }
        public List<ProdutoModel> Produtos { get; set; }
        public DadosPessoaisModel DadosPessoais { get; set; }
        public DadosPagamentoModel DadosPagamento { get; set; }

        public VendaModel() 
        {
            Id = 0;
            Status = string.Empty;
            ValorTotal = 0;
            Endereco = new EnderecoModel();
            Produtos = new List<ProdutoModel>();
            DadosPessoais = new DadosPessoaisModel();
            DadosPagamento = new DadosPagamentoModel();
        }
    }
}
