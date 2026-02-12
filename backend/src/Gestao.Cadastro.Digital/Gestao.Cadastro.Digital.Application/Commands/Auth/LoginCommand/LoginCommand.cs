using Gestao.Cadastro.Digital.Application.DTOs.Response;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.Auth.LoginCommand;

public record LoginCommand(string Login, string Senha)
: IRequest<AuthResponseDto>;
