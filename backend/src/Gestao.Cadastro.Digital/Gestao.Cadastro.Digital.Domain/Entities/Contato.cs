namespace Gestao.Cadastro.Digital.Domain.Entities;

public class Contato
{
    public long IdContato { get; set; }
    public long IdPessoa { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Endereco { get; set; }
}
