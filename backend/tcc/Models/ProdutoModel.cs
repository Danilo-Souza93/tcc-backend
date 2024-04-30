using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace tcc.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int QuantidadeEstoque { get; set; }
        public float Valor  { get; set; }
        public string dt_lote { get; set; }

        public ProdutoModel() 
        { 
            Id = Guid.Empty;
            Nome = string.Empty;
            Detalhe = string.Empty;
            QuantidadeEstoque = 0;
            Valor = 0;
            dt_lote = string.Empty;
        }
    }
   
}
