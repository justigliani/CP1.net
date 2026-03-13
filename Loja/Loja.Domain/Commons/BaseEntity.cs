namespace Loja.Domain.Commons;

public class EntidadeBase
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public bool Ativo { get; protected set; } = true;
}