﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using tcc.EntityModels;
using tcc.Models;

public class VendaModelMapping : IEntityTypeConfiguration<VendaEntityModel>
{
	public void Configure(EntityTypeBuilder<VendaEntityModel> builder)
	{
        // Define o nome da tabela
        builder.ToTable("vendas");

        //builder.HasKey(v => v.VendaId);

        // Configura a chave primária
        builder.Property(v => v.VendaId)
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired();

        // Configura a propriedade Status
        builder.Property(v => v.Status)
               .HasColumnName("status")
               .IsRequired();

        // Configura a propriedade ValorTotal
        builder.Property(v => v.ValorTotal)
               .HasColumnName("valor_total")
               .IsRequired();

        // Configura a relação com EnderecoModel
        builder.OwnsOne(v => v.Endereco, endereco =>
        {
            endereco.Property(e => e.Cep)
                .IsRequired();

            endereco.Property(e => e.Numero)
                .IsRequired();
        });

        // Configura a relação com DadosPessoaisModel
        builder.OwnsOne(v => v.DadosPessoais, dadosPessoais =>
        {
            dadosPessoais.Property(e => e.Cpf)
                .HasMaxLength(14)
                .IsRequired();
        });

        builder.Property(v => v.StatusPagamento)
            .HasColumnName("status_pagamento")
            .IsRequired();
    }
}
