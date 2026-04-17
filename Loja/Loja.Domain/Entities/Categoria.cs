using Loja.Domain.Commons;
namespace Loja.Domain.Entities;

// N:1 -> Produto
public class Categoria : EntidadeBase
{
    public string Nome { get; private set; } = string.Empty;

    // FK explícita
    public Guid ProdutoId { get; set; }

    // Navegação
    public Produto? Produto { get; set; }

    protected Categoria() { } // necessário para o EF Core

    public Categoria(string nome, Guid produtoId)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
            throw new Exception("Categoria de produto inválida");
        Nome = nome;
        ProdutoId = produtoId;
    }

    public override string ToString() => $"Categoria: {Nome}";
}