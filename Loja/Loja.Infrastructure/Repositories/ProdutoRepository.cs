using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly LojaDbContext _context;

    public ProdutoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Produto?> GetByIdAsync(Guid id) =>
        await _context.Produtos.FindAsync(id);

    public async Task<IEnumerable<Produto>> GetAllAsync() =>
        await _context.Produtos.ToListAsync();

    public async Task AddAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var produto = await GetByIdAsync(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}