using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace tcc.Models
{
    public class VendaModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public float ValorTotal { get; set; }
        public EnderecoModel Endereco { get; set; }
        public List<ProdutosVendidos> ProdutosVendidos { get; set; }
        public DadosPessoaisModel DadosPessoais { get; set; }
        public DadosPagamentoModel DadosPagamento { get; set; }

        public VendaModel() 
        {
            Id = new Guid();
            Status = string.Empty;
            ValorTotal = 0;
            Endereco = new EnderecoModel();
            ProdutosVendidos = new List<ProdutosVendidos>();
            DadosPessoais = new DadosPessoaisModel();
            DadosPagamento = new DadosPagamentoModel();
        }
    }
}
