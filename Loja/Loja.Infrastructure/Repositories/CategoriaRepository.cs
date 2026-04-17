using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly LojaDbContext _context;

    public CategoriaRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria?> GetByIdAsync(Guid id) =>
        await _context.Categorias.FindAsync(id);

    public async Task<IEnumerable<Categoria>> GetAllAsync() =>
        await _context.Categorias.ToListAsync();

    public async Task AddAsync(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var categoria = await GetByIdAsync(id);
        if (categoria != null)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}