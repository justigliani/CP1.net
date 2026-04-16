using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infrastructure.Mappings;

public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");
        builder.HasKey(e => e.IdEndereco);
        builder.Property(e => e.Rua).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Estado).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Cep).IsRequired().HasMaxLength(10);
    }
}