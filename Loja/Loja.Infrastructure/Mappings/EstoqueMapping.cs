using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infrastructure.Mappings;

public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
{
    public void Configure(EntityTypeBuilder<Estoque> builder)
    {
        builder.ToTable("Estoques");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.QuantidadeDisponivel).IsRequired();
        builder.Property(e => e.DataAtualizacao).IsRequired();
    }
}