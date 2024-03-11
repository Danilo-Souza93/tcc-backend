using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace tcc.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int QuantidadeEstoque { get; set; }
        public float Valor  { get; set; }

        public ProdutoModel() 
        { 
            Id = 0;
            Nome = string.Empty;
            Detalhe = string.Empty;
            QuantidadeEstoque = 0;
            Valor = 0;
        }
    }
   
}
