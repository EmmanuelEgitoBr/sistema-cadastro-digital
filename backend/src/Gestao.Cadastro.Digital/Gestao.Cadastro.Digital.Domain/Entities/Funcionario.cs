using Gestao.Cadastro.Digital.Domain.Enums;

namespace Gestao.Cadastro.Digital.Domain.Entities;

public class Funcionario
{
    public long IdFuncionario { get; set; }
    public long IdPessoa { get; set; }
    public string? Cargo { get; set; }
    public string? Departamento { get; set; }
    public TipoFuncionario TipoFuncionario { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime DataDemissao { get; set; }
}