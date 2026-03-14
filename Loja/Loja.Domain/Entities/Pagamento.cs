namespace Loja.Domain.Entities;

// 1:1 -> Pedido --- Pagamento
public class Pagamento
{
    public int IdPagamento { get; set; }
    
    public string MetodoPagamento { get; set; } = string.Empty; // validando a obrigatoriedade do campo
    
    public string Status { get; set; } = string.Empty; // validando a obrigatoriedade do campo
    
    public DateTime DataPagamento { get; set; }
    
    public int PedidoId { get; set; }
    
    public Pedido? Pedido { get; set; }
    
}
