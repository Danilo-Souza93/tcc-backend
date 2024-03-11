using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace tcc.Models
{
    public class DadosPessoaisModel
    {
        [Key]
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        

        public DadosPessoaisModel() 
        { 
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Cpf = 0;
        }
    }
}
