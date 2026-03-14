namespace Loja.Domain.Entities;

public class Pedido
{

    public int IdPedido { get; set; }
    
    public DateTime DataPedido { get; set; }

    public string Status { get; set; } = string.Empty;
    
    public decimal ValorTotal { get; set; }
    
    public int ClienteId { get; set; }
    
    public Cliente? Cliente { get; set; }
    
    public int PagamentoId { get; set; }
    
    public Pagamento? Pagamento { get; set; }
    
    public ICollection<ItemPedido>? Itens { get; set; }
    
    // Pedido controla pagamentos
    // adiciono aqui esse metodo para fazer sentido a relação das entidades
    public void AdicionarPagamento(Pagamento pagamento)
    {
        if (Pagamento != null)
            throw new Exception("Pedido já possui pagamento.");
        
        Pagamento = pagamento;
        
    }
    
}