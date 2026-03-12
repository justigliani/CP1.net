namespace Loja.Domain.Entities;

public class Categoria
{
    public int IdCategoria { get; set; }
    
    public string Nome { get; set; } = string.Empty;
    
    public int ProdutoId { get; set; }
    
    public Produto? Produto { get; set; }
}