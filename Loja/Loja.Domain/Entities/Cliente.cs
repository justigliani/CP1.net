namespace Loja.Domain.Entities;

// 1:N -> Pedido
// 1:N -> Endereco
public class Cliente
{
    public int IdCliente { get; set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string? Telefone { get; set; }
    public DateTime DataCadastro { get; private set; } = DateTime.Now;

    // Navegação
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public Cliente(string nome, string email, string senha)
    {
        if (string.IsNullOrEmpty(nome) || nome.Length < 2)
            throw new Exception("Nome inválido");
        Nome = nome;

        if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            throw new Exception("Email inválido");
        Email = email;

        if (string.IsNullOrEmpty(senha) || senha.Length < 6)
            throw new Exception("Senha deve ter no mínimo 6 caracteres");
        Senha = senha;
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        Enderecos.Add(endereco);
    }

    public override string ToString()
    {
        return $"Cliente: {Nome} - {Email}";
    }
}