using Gestao.Cadastro.Digital.Application.DTOs.Response;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.Auth.RefreshTokenCommand;

public record RefreshTokenCommand(string RefreshToken)
: IRequest<AuthResponseDto>;
