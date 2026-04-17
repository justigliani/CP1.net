using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface IProdutoRepository
{
    Task<Produto?> GetByIdAsync(Guid id);
    Task<IEnumerable<Produto>> GetAllAsync();
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(Guid id);
}