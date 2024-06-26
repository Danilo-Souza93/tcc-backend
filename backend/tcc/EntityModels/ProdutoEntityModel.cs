﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tcc.EntityModels
{
    [Table("produtos")]
    public class ProdutoEntityModel: EntityBase
    {
        [Required]
        [Column("produto_id")]
        public int Id { get; set; }

        [Required]
        [Column("produto_guid")]
        public Guid Uuid { get; set; }

        [Required]
        [Column("produto_name")]
        [
            MaxLength(100, ErrorMessage = "O produto pode ter no maximo 100 caracteres"), 
            MinLength(3, ErrorMessage = "O produto precisa ter pelo menos 3 caracteres")
        ]
        public string Nome { get; set; }

        [Column("detalhe")]
        [MaxLength(250, ErrorMessage ="Detalhe em no maximo 250 caracteres")]
        public string Detalhe { get; set; }

        [Column("quantidade")]
        public int QuantidadeEstoque { get; set; }

        [Required]
        [Column("valor")]
        [Range(0, double.MaxValue, ErrorMessage ="O valor do produto precisa ser maior que 0")]
        public float Valor { get; set; }

        [Required]
        [Column("dt_lote")]
        public string dt_lote { get; set; }

        public List<VendaProdutosEntityModel> ProdutoVendas { get; set; }
    }
}
