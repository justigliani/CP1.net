using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface IItemPedidoRepository
{
    Task<ItemPedido?> GetByIdAsync(int id);
    Task<IEnumerable<ItemPedido>> GetAllAsync();
    Task AddAsync(ItemPedido itemPedido);
    Task UpdateAsync(ItemPedido itemPedido);
    Task DeleteAsync(int id);
}