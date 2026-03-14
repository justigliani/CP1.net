namespace Loja.Domain.Entities;

// 1:N Cliente ---< Endereco
public class Cliente
{
    public int IdCliente { get; set; }
    
    public string Nome { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string Senha { get; set; } = string.Empty;
    
    public string? Telefone { get; set; }
    
    public DateTime DataCadastro { get; set; }
    
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    
    //Metodo para adicionar um novo endereço do cliente 
    public void AdicionarEndereco(Endereco endereco)
    {
        Enderecos.Add(endereco);
    }
    
    
}