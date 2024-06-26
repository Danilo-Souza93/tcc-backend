﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using tcc.Models;

namespace tcc.EntityModels
{
    [Table("vendas")]
    public class VendaEntityModel: EntityBase
    {
        [Required]
        [Column("venda_id")]
        public Guid VendaId { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("valor_total")]
        [Range(0.01, double.MaxValue, ErrorMessage="O valor total deve ser maior que 0")]
        public float ValorTotal { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Deve conter pelo menos um produto")]
        public List<VendaProdutosEntityModel> VendaProdutos { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Deve conter um unico endereço")]
        public virtual EnderecoModel Endereco { get; set; } // Propriedade de tipo complexo

        [Required]
        [Range(0.01, int.MaxValue, ErrorMessage = "Deve conter pelo menos um dado para contato")]
        public virtual DadosPessoaisModel DadosPessoais { get; set; }

        [Required]
        [MaxLength(100)]
        public string StatusPagamento {  get; set; }
    }
}
