using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly LojaDbContext _context;

    public PagamentoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Pagamento?> GetByIdAsync(int id) =>
        await _context.Pagamentos.FindAsync(id);

    public async Task<IEnumerable<Pagamento>> GetAllAsync() =>
        await _context.Pagamentos.ToListAsync();

    public async Task AddAsync(Pagamento pagamento)
    {
        await _context.Pagamentos.AddAsync(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pagamento pagamento)
    {
        _context.Pagamentos.Update(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pagamento = await GetByIdAsync(id);
        if (pagamento != null)
        {
            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();
        }
    }
}