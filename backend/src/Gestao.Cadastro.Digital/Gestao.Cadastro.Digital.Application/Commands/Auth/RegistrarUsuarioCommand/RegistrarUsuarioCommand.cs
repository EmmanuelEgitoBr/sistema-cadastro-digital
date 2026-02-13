using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.Auth.RegistrarUsuarioCommand;

public record RegistrarUsuarioCommand(
    string Nome,
    string Email,
    string Cpf,
    string Login,
    string Senha,
    string Role) : IRequest<long>;
