using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("valor_total")]
        [Range(0.01, double.MaxValue, ErrorMessage="O valor total deve ser maior que 0")]
        public float ValorTotal { get; set; }

        [Required]
        [ForeignKey("endereco_id")]
        [Range(1, int.MaxValue, ErrorMessage = "É necessário somente um endereço para entrega")]
        public int? EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }

        [Required]
        [ForeignKey("produtos_id")]
        [Range(0, int.MaxValue, ErrorMessage = "É necessário um ou mais produtos")]
        public int? ProdutosId { get; set; }
        public List<ProdutoModel> Produtos { get; set; }

        [Required]
        [ForeignKey("dados_pessoais_id")]
        [Range(0, int.MaxValue, ErrorMessage ="É necessario informar os dados pessoais")]
        public int? DadosPessoaisId { get; set; }
        public DadosPessoaisModel DadosPessoais { get; set; }

        [Required]
        [ForeignKey("dados_pagamento_id")]
        [Range(0, int.MaxValue, ErrorMessage ="É necessário uma forma de pagamento")]
        public int? DadosPagamentoId { get; set; }
        public DadosPagamentoModel DadosPagamento { get; set; }
    }
}
