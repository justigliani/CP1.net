using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly LojaDbContext _context;

    public EstoqueRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Estoque?> GetByIdAsync(Guid id) =>
        await _context.Estoques.FindAsync(id);

    public async Task<IEnumerable<Estoque>> GetAllAsync() =>
        await _context.Estoques.ToListAsync();

    public async Task AddAsync(Estoque estoque)
    {
        await _context.Estoques.AddAsync(estoque);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Estoque estoque)
    {
        _context.Estoques.Update(estoque);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var estoque = await GetByIdAsync(id);
        if (estoque != null)
        {
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
        }
    }
}