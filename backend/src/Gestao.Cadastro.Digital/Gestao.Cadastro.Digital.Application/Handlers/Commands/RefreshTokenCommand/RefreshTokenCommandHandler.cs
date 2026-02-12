using Gestao.Cadastro.Digital.Application.DTOs.Response;
using Gestao.Cadastro.Digital.Application.Interfaces.Auth;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using MediatR;
using Command = Gestao.Cadastro.Digital.Application.Commands.Auth.RefreshTokenCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.RefreshTokenCommand;

public class RefreshTokenCommandHandler : IRequestHandler<Command.RefreshTokenCommand, AuthResponseDto>
{
    private readonly IUsuarioService _usuarioService;
    private readonly IJwtTokenService _jwtService;

    public RefreshTokenCommandHandler(IUsuarioService usuarioService, IJwtTokenService jwtService)
    {
        _usuarioService = usuarioService;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> Handle(Command.RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refresh = await _usuarioService.ObterRefreshTokenAsync(request.RefreshToken)
?? throw new DomainException("Refresh token inválido");


        if (refresh.Revogado || refresh.ExpiraEm < DateTime.Now)
            throw new DomainException("Refresh token expirado");


        var usuario = await _usuarioService.ObterPorLoginAsync(refresh.UsuarioId.ToString())
        ?? throw new DomainException("Usuário inválido");


        return new AuthResponseDto(
        _jwtService.GerarToken(usuario),
        _jwtService.GerarRefreshToken());
    }
}
