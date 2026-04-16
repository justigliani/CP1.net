using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infrastructure.Mappings;

public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.ToTable("ItensPedido");
        builder.HasKey(i => i.IdItemPedido);

        builder.Property(i => i.Quantidade)
            .IsRequired();

        builder.Property(i => i.PrecoUnitario)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        // N:1 -> Pedido  (resolve o N:N entre Pedido e Produto)
        builder.HasOne(i => i.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        // N:1 -> Produto
        builder.HasOne(i => i.Produto)
            .WithMany(p => p.ItensPedido)
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índice composto para evitar duplicata no mesmo pedido
        builder.HasIndex(i => new { i.PedidoId, i.ProdutoId }).IsUnique();
    }
}