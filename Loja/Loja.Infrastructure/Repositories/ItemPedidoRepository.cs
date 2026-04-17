using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class ItemPedidoRepository : IItemPedidoRepository
{
    private readonly LojaDbContext _context;

    public ItemPedidoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<ItemPedido?> GetByIdAsync(int id) =>
        await _context.ItensPedido.FindAsync(id);

    public async Task<IEnumerable<ItemPedido>> GetAllAsync() =>
        await _context.ItensPedido.ToListAsync();

    public async Task AddAsync(ItemPedido itemPedido)
    {
        await _context.ItensPedido.AddAsync(itemPedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ItemPedido itemPedido)
    {
        _context.ItensPedido.Update(itemPedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
        {
            _context.ItensPedido.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}