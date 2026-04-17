using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface ICategoriaRepository
{
    Task<Categoria?> GetByIdAsync(Guid id);
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task AddAsync(Categoria categoria);
    Task UpdateAsync(Categoria categoria);
    Task DeleteAsync(Guid id);
}