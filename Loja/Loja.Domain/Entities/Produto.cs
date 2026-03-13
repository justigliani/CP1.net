using Loja.Domain.Commons;

namespace Loja.Domain.Entities;

// 1:N -> Categoria, // 1:N -> Estoque, // 1:N -> ItemPedido.
public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }

    public List<Categoria> Categorias { get; private set; }
    public List<Estoque> Estoques { get; private set; }
    public List<ItemPedido> ItensPedido { get; private set; }

    public Produto(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
            throw new Exception("Nome do produto inválido");

        if (preco < 0)
            throw new Exception("Preço inválido");

        Nome = nome;
        Preco = preco;

        Categorias = new List<Categoria>();
        Estoques = new List<Estoque>();
        ItensPedido = new List<ItemPedido>();
    }

    public override string ToString()
    {
        return $"{Nome} - R$ {Preco}";
    }
}