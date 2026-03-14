namespace Loja.Domain.Entities;

// N:1 -> Cliente
// 1:N -> ItemPedido
// 1:1 -> Pagamento
public class Pedido
{
    public int IdPedido { get; set; }
    public DateTime DataPedido { get; private set; } = DateTime.Now;
    public string Status { get; private set; }
    public decimal ValorTotal { get; set; }

    // FK
    public int ClienteId { get; set; }

    // Navegação
    public Cliente? Cliente { get; set; }
    public Pagamento? Pagamento { get; set; }
    public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

    public Pedido(int clienteId, string status = "Pendente")
    {
        if (clienteId <= 0)
            throw new Exception("ClienteId inválido");
        ClienteId = clienteId;

        Status = status;
    }

    public void AtualizarStatus(string novoStatus)
    {
        if (string.IsNullOrEmpty(novoStatus))
            throw new Exception("Status inválido");
        Status = novoStatus;
    }

    public void AdicionarPagamento(Pagamento pagamento)
    {
        if (Pagamento != null)
            throw new Exception("Pedido já possui pagamento");
        Pagamento = pagamento;
    }

    public override string ToString()
    {
        return $"Pedido: {IdPedido} - {Status} - R$ {ValorTotal}";
    }
}