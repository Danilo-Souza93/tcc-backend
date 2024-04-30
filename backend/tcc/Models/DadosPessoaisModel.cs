using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc.Models
{
    public class DadosPessoaisModel
    {
        [Column("pessoal_cpf")]
        public string Cpf { get; set; }
        [Column("pessoal_nome")]
        public string Nome { get; set; }
        [Column("pessoal_sobrenome")]
        public string Sobrenome { get; set; }
        

        public DadosPessoaisModel() 
        { 
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Cpf = string.Empty;
        }
    }
}
