using System.ComponentModel.DataAnnotations;

namespace tcc.Models
{
    public class EnderecoModel
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }

        public EnderecoModel() 
        {
            EnderecoId = 0;
            Rua = string.Empty;
            Numero = 0;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Cep = 0;
        }
    }
}
