using Loja.Domain.Commons;

namespace Loja.Domain.Entities;

// N:1 -> Produto
public class Estoque : EntidadeBase
{
    public int QuantidadeDisponivel { get; private set; }
    public DateTime DataAtualizacao { get; private set; }
    public Produto Produto { get; private set; }
    public Estoque(int quantidadeDisponivel, Produto produto)
    {
        if (quantidadeDisponivel < 0)
            throw new Exception("Quantidade inválida");

        QuantidadeDisponivel = quantidadeDisponivel;
        DataAtualizacao = DateTime.Now;
        Produto = produto;
    }
    public override string ToString()
    {
        return $"Estoque: {QuantidadeDisponivel} unidade(s)";
    }
}