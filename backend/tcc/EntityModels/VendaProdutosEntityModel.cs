using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tcc.Models;

namespace tcc.EntityModels
{
    [Table("venda_produto")]
    public class VendaProdutosEntityModel: EntityBase
    {
        [Required]
        [Column("venda_produto")]
        public Guid VendaProdutosId { get; set;}
        [Required]
        [Column("venda_id")]
        public VendaEntityModel Venda { get; set;}
        [Required]
        [Column("produtos")]
        public List<ProdutosVendidos> ListProdutos { get; set;}
    }
}
