using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc.Models
{
    public class EnderecoModel
    {
        [Column("endereco_id")]
        public int EnderecoId { get; set; }
        [Column("endereco_rua")]
        public string Rua { get; set; }
        [Column("endereco_numero")]
        public int Numero { get; set; }
        [Column("endereco_bairro")]
        public string Bairro { get; set; }
        [Column("endereco_cidade")]
        public string Cidade { get; set; }
        [Column("endereco_estado")]
        public string Estado { get; set; }
        [Column("endereco_cep")]
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
