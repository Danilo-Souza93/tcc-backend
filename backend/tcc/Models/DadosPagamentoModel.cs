using System.ComponentModel.DataAnnotations;

namespace tcc.Models
{
    public class DadosPagamentoModel
    {
        public int DadosPagamentoId { get; set; }
        public Cartao Debito { get; set; }
        public Cartao Credito { get; set; }
        //public Pix Pix { get; set; }
        //public Boleto Boleto { get; set; } 

        public DadosPagamentoModel() 
        {
            DadosPagamentoId = 0;
            Debito = new Cartao();
            Credito = new Cartao();
            //Pix = new Pix();
            //Boleto = new Boleto();
        }
    }

    public class Cartao
    {
        public int Id { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoSeguranca { get; set; }
        public string DtValidade { get; set; }
        public string NomeCartao { get; set; }
        public string Bandeira { get; set; }

        public Cartao() 
        {
            Id = 0;
            NumeroCartao = string.Empty;
            CodigoSeguranca = string.Empty;
            DtValidade = string.Empty;
            NomeCartao = string.Empty;
            Bandeira = string.Empty;
        }
    }

    //public class Pix
    //{
    //    [Key]
    //    public int Cnpj { get; }
    //}

    //public class Boleto
    //{

    //}
}
