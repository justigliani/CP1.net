using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infrastructure.Mappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(p => p.IdPedido);

        builder.Property(p => p.DataPedido).IsRequired();

        builder.Property(p => p.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal(10,2)");

        // 1:1 -> Pagamento (opcional: pedido pode existir sem pagamento ainda)
        builder.HasOne(p => p.Pagamento)
            .WithOne(pg => pg.Pedido)
            .HasForeignKey<Pagamento>(pg => pg.PedidoId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}