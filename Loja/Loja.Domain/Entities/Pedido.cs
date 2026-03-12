namespace Loja.Domain.Entities;

public class Pedido
{
    public int IdPedido { get; set; }
    
    public DateTime DatePedido { get; set; }

    public string Status { get; set; } = string.Empty;
    
    public decimal ValorTotal { get; set; }
    
    public int ClienteId { get; set; }
    
    public int PagamentoId { get; set; }
    
    public Cliente? Cliente { get; set; }
    
    public Pagamento? Pagamento { get; set; }
    
    public ICollection<ItemPedido>? Itens { get; set; }
}