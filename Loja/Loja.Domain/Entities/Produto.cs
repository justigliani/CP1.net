namespace Loja.Domain.Entities;

public class Produto
{
    public int IdProduto { get; set; }
    
    public string Nome { get; set; } = string.Empty;
    
    public decimal Preco { get; set; }
    
    public ICollection<ItemPedido>? ItensPedido { get; set; }
    
    public ICollection<Estoque>? Estoques { get; set; }
    
    public ICollection<Categoria>? Categorias { get; set; }
}