namespace Loja.Domain.Entities;

public class ItemPedido
{
    public int IdItemPedido { get; set; }
    
    public int Quantidade { get; set; }
    
    public decimal PrecoUnitario { get; set; }
    
    public int PedidoId { get; set; }
    
    public int ProdutoId { get; set; }
    
    public Pedido? Pedido  { get; set; }
    
    public Produto? Produto { get; set; }
}