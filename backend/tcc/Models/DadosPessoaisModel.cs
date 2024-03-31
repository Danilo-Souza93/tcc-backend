using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers;
using System.ComponentModel.DataAnnotations;

namespace tcc.Models
{
    public class DadosPessoaisModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        

        public DadosPessoaisModel() 
        { 
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Cpf = string.Empty;
        }
    }
}
