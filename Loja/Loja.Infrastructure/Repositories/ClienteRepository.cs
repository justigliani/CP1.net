using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Loja.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly LojaDbContext _context;

    public ClienteRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> GetByIdAsync(int id) =>
        await _context.Clientes.FindAsync(id);

    public async Task<IEnumerable<Cliente>> GetAllAsync() =>
        await _context.Clientes.ToListAsync();

    public async Task AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await GetByIdAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}