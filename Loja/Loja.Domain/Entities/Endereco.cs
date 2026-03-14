namespace Loja.Domain.Entities;

// 1:N - Cliente ---< Endereco
public class Endereco
{
    public int IdEndereco { get; set; }
    
    public string Rua { get; set; } = string.Empty;
    
    public string Cidade { get; set; } = string.Empty;
    
    public string Estado { get; set; } = string.Empty;
    
    public string Cep { get; set; } = string.Empty;

    public int ClienteId { get; set; } 
    
    public Cliente? Cliente { get; set; }
}