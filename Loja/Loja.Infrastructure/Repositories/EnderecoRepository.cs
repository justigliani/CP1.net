namespace Loja.Infrastructure.Repositories;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly LojaDbContext _context;

    public EnderecoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Endereco?> GetByIdAsync(int id) =>
        await _context.Enderecos.FindAsync(id);

    public async Task<IEnumerable<Endereco>> GetAllAsync() =>
        await _context.Enderecos.ToListAsync();

    public async Task AddAsync(Endereco endereco)
    {
        await _context.Enderecos.AddAsync(endereco);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Endereco endereco)
    {
        _context.Enderecos.Update(endereco);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var endereco = await GetByIdAsync(id);
        if (endereco != null)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}