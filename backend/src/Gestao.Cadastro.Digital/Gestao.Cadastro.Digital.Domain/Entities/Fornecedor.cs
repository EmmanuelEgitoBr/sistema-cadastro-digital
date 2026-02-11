namespace Gestao.Cadastro.Digital.Domain.Entities;

public class Fornecedor
{
    public long IdFornecedor { get; set; }
    public long IdPessoa { get; set; }
    public string? Departamento { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
