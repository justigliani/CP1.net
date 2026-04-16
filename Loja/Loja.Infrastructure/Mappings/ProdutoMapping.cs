using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infrastructure.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        // EntidadeBase usa Guid como PK
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(p => p.Ativo)
            .IsRequired()
            .HasDefaultValue(true);

        // 1:N -> Categorias
        builder.HasMany(p => p.Categorias)
            .WithOne(c => c.Produto)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N -> Estoques
        builder.HasMany(p => p.Estoques)
            .WithOne(e => e.Produto)
            .OnDelete(DeleteBehavior.Cascade);
    }
}