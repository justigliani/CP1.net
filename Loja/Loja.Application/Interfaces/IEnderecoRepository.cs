using Loja.Domain.Entities;

namespace Loja.Application.Interfaces;

public interface IEnderecoRepository
{
    Task<Endereco?> GetByIdAsync(int id);
    Task<IEnumerable<Endereco>> GetAllAsync();
    Task AddAsync(Endereco endereco);
    Task UpdateAsync(Endereco endereco);
    Task DeleteAsync(int id);
}