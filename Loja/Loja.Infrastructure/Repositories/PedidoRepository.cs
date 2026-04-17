using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly LojaDbContext _context;

    public PedidoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido?> GetByIdAsync(int id) =>
        await _context.Pedidos.FindAsync(id);

    public async Task<IEnumerable<Pedido>> GetAllAsync() =>
        await _context.Pedidos.ToListAsync();

    public async Task AddAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pedido = await GetByIdAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}