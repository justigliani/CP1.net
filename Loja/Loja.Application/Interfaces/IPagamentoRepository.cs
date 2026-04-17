using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface IPagamentoRepository
{
    Task<Pagamento?> GetByIdAsync(int id);
    Task<IEnumerable<Pagamento>> GetAllAsync();
    Task AddAsync(Pagamento pagamento);
    Task UpdateAsync(Pagamento pagamento);
    Task DeleteAsync(int id);
}