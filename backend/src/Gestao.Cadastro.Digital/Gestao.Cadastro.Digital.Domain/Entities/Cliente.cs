namespace Gestao.Cadastro.Digital.Domain.Entities;

public class Cliente
{
    public long IdCliente { get; set; }
    public long IdPessoa { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}