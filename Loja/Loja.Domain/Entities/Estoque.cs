using Loja.Domain.Commons;
namespace Loja.Domain.Entities;

// N:1 -> Produto
public class Estoque : EntidadeBase
{
    public int QuantidadeDisponivel { get; private set; }
    public DateTime DataAtualizacao { get; private set; }

    // FK explícita
    public Guid ProdutoId { get; set; }

    // Navegação
    public Produto? Produto { get; set; }

    protected Estoque() { } // necessário para o EF Core

    public Estoque(int quantidadeDisponivel, Guid produtoId)
    {
        if (quantidadeDisponivel < 0)
            throw new Exception("Quantidade inválida");
        QuantidadeDisponivel = quantidadeDisponivel;
        DataAtualizacao = DateTime.Now;
        ProdutoId = produtoId;
    }

    public override string ToString() => $"Estoque: {QuantidadeDisponivel} unidade(s)";
}