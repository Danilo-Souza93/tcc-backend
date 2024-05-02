using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc.Models
{
    public class DadosPagamentoModel
    {
        public Cartao Cartao { get; set; }
        //public Pix Pix { get; set; }
        //public Boleto Boleto { get; set; } 

        public DadosPagamentoModel() 
        {
            Cartao = new Cartao();
            //Pix = new Pix();
            //Boleto = new Boleto();
        }
    }

    public class Cartao
    {
        [Column("cartao_numero")]
        public string NumeroCartao { get; set; }

        [NotMapped]
        public string CodigoSeguranca { get; set; }

        [NotMapped]
        public string DtValidade { get; set; }

        [Column("cartao_nome")]
        public string NomeCartao { get; set; }

        [Column("cartao_bandeira")]
        public string Bandeira { get; set; }

        [Column("cartao_tipo")]
        public string Tipo { get; set; }

        public Cartao() 
        {
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
