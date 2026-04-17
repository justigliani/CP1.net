using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface IEstoqueRepository
{
    Task<Estoque?> GetByIdAsync(Guid id);
    Task<IEnumerable<Estoque>> GetAllAsync();
    Task AddAsync(Estoque estoque);
    Task UpdateAsync(Estoque estoque);
    Task DeleteAsync(Guid id);
}