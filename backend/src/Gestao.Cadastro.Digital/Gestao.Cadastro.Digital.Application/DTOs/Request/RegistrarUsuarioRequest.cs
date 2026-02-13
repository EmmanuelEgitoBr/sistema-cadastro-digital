namespace Gestao.Cadastro.Digital.Application.DTOs.Request;

public record RegistrarUsuarioRequest(
    string Nome,
    string Email,
    string Cpf,
    string Login,
    string Senha,
    string Role);
