using ControleFinanceiro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Data.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Data).IsRequired(true);
            builder.Property(c => c.Descricao).HasMaxLength(300).IsRequired(false);
            builder.Property(c => c.Tipo).IsRequired(true);
            builder.Property(c=>c.Valor).HasColumnType("decimal(10,2)").IsRequired(true);
            builder.Property(c => c.Conta).HasMaxLength(50).IsRequired(true);
            builder.Ignore(p => p.ValidationResult);
            builder.Ignore(p => p.CascadeMode);
        }
    }
}
