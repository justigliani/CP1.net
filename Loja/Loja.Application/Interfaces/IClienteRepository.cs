using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface IClienteRepository
{
    Task<Cliente?> GetByIdAsync(int id);
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task AddAsync(Cliente cliente);
    Task UpdateAsync(Cliente cliente);
    Task DeleteAsync(int id);
}