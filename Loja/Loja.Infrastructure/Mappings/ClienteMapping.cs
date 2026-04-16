using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infrastructure.Mappings;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(c => c.IdCliente);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.Senha)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Telefone)
            .HasMaxLength(20);

        builder.Property(c => c.DataCadastro)
            .IsRequired();

        // 1:N -> Enderecos
        builder.HasMany(c => c.Enderecos)
            .WithOne(e => e.Cliente)
            .HasForeignKey(e => e.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N -> Pedidos
        builder.HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}