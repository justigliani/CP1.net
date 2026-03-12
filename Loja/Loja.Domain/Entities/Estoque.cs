namespace Loja.Domain.Entities;

public class Estoque
{
    public int IdEstoque { get; set; }
    
    public int QuantidadeDisponivel { get; set; }
    
    public DateTime DataAtualizacao { get; set; }
    
    public int ProdutoId { get; set; }
    
    public Produto? Produto { get; set; }
}