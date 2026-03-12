namespace Loja.Domain.Entities;

public class Pagamento
{
    public int IdPagamento { get; set; }
    
    public string MetodoPagameto { get; set; } = string.Empty;
    
    public string Status { get; set; } = string.Empty;
    
    public DateTime DataPagamento { get; set; }
    
    public Pedido? Pedido { get; set; }
}