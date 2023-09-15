namespace tcc.Models
{
    public class DadosPagamentoModel
    {
        public Cartao Debito { get; set; }
        public List<Cartao> Credito { get; set; }
        public Pix Pix { get; set; }
        //public Boleto Boleto { get; set; } 

        public DadosPagamentoModel() 
        { 
            Debito = new Cartao();
            Credito = new List<Cartao>();
            Pix = new Pix();
            //Boleto = new Boleto();
        }
    }

    public class Cartao
    {
        public int NumeroCartao { get; set; }
        public int CodigoSeguranca { get; set; }
        public string DtValidade { get; set; }
        public string NomeCartao { get; set; }
        public string Bandeira { get; set; }
    }

    public class Pix
    {
        public int Cnpj { get; }
    }

    //public class Boleto
    //{

    //}
}
