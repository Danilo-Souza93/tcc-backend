using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc.Models
{
    public class DadosPagamentoModel
    {
        [Column("pagamento_id")]
        public int DadosPagamentoId { get; set; }
        //public Cartao Debito { get; set; }
        //public Cartao Credito { get; set; }
        public Cartao Cartao { get; set; }
        //public Pix Pix { get; set; }
        //public Boleto Boleto { get; set; } 

        public DadosPagamentoModel() 
        {
            DadosPagamentoId = 0;
            //Debito = new Cartao();
            //Credito = new Cartao();
            //Pix = new Pix();
            //Boleto = new Boleto();
        }
    }

    public class Cartao
    {
        [Column("cartao_id")]
        public int Id { get; set; }
        [Column("cartao_numero")]
        public string NumeroCartao { get; set; }
        [Column("cartao_codigo_seguranca")]
        public string CodigoSeguranca { get; set; }
        [Column("cartao_dt_validade")]
        public string DtValidade { get; set; }
        [Column("cartao_nome")]
        public string NomeCartao { get; set; }
        [Column("cartao_bandeira")]
        public string Bandeira { get; set; }
        [Column("cartao_tipo")]
        public string Tipo { get; set; }

        public Cartao() 
        {
            Id = 0;
            NumeroCartao = string.Empty;
            CodigoSeguranca = string.Empty;
            DtValidade = string.Empty;
            NomeCartao = string.Empty;
            Bandeira = string.Empty;
            Tipo = string.Empty;
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
