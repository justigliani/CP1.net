namespace Loja.Domain.Entities;

// N:N resolvido -> Produto x Pedido
// N:1 -> Pedido
// N:1 -> Produto
public class ItemPedido
{
    public int IdItemPedido { get; set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }

    // FKs
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }

    // Navegação
    public Pedido? Pedido { get; set; }
    public Produto? Produto { get; set; }

    public ItemPedido(int pedidoId, int produtoId, int quantidade, decimal precoUnitario)
    {
        if (pedidoId <= 0)
            throw new Exception("PedidoId inválido");
        PedidoId = pedidoId;

        if (produtoId <= 0)
            throw new Exception("ProdutoId inválido");
        ProdutoId = produtoId;

        if (quantidade < 1)
            throw new Exception("Quantidade deve ser maior que zero");
        Quantidade = quantidade;

        if (precoUnitario < 0)
            throw new Exception("Preço inválido");
        PrecoUnitario = precoUnitario;
    }

    public decimal CalcularSubtotal() => Quantidade * PrecoUnitario;

    public override string ToString()
    {
        return $"Item: {ProdutoId} - Qtd: {Quantidade} - R$ {PrecoUnitario}";
    }
}