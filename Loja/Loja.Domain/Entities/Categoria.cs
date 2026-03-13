using Loja.Domain.Commons;

namespace Loja.Domain.Entities;

// N:1 -> Produto
public class Categoria : EntidadeBase
{
    public string Nome { get; private set; }
    public Produto Produto { get; private set; }
    public Categoria(string nome, Produto produto)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
            throw new Exception("Nome da categoria inválido");

        Nome = nome;
        Produto = produto;
    }
    public override string ToString()
    {
        return $"Categoria: {Nome}";
    }
}