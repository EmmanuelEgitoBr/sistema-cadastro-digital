namespace Gestao.Cadastro.Digital.Application.DTOs;

public record CriarPessoaDto
{
    public long IdPessoa { get; protected set; }
    public int TipoPessoa { get; set; }
    public int CategoriaPessoa { get; set; }
}
