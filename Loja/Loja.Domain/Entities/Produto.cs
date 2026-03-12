namespace Loja.Domain.Entities;

public class Produto
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = string.Empty;

    public decimal Preco { get; set; }
    
    public ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
    
    public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
    
    public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
}