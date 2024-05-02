using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tcc.Models;

namespace tcc.EntityModels
{
    [Table("venda_produto")]
    public class VendaProdutosEntityModel: EntityBase
    {
        //[Required]
        //[Column("venda_produto_id")]
        //public int VendaProdutosId { get; set;}
        [Required]
        [Column("venda_id")]
        public Guid VendaId { get; set; }

        [ForeignKey("VendaId")]
        public VendaEntityModel Venda { get; set;}

        [Required]
        [Column("produto_id")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public ProdutoEntityModel Produto { get; set; }

        [Required]
        [Column("venda_produto_quantidade")]
        public int Quantidade { get; set; }
        //[Required]
        //[Column("produtos")]
        //public List<ProdutosVendidos> ListProdutos { get; set;}
    }
}
