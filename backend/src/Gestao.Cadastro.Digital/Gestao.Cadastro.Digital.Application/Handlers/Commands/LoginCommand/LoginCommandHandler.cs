using Gestao.Cadastro.Digital.Application.DTOs.Response;
using Gestao.Cadastro.Digital.Application.Interfaces.Auth;
using Gestao.Cadastro.Digital.Domain.Entities.Auth;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using MediatR;
using Command = Gestao.Cadastro.Digital.Application.Commands.Auth.LoginCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<Command.LoginCommand, AuthResponseDto>
{
    private readonly IUsuarioService _usuarioService;
    private readonly IJwtTokenService _jwtService;
    private readonly IPasswordHasher _hasher;

    public LoginCommandHandler(
    IUsuarioService usuarioService,
    IJwtTokenService jwtService,
    IPasswordHasher hasher)
    {
        _usuarioService = usuarioService;
        _jwtService = jwtService;
        _hasher = hasher;
    }

    public async Task<AuthResponseDto> Handle(Command.LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _usuarioService.ObterPorLoginAsync(request.Login)
            ?? throw new DomainException("Usuário ou senha inválidos");


        if (!_hasher.Verify(request.Senha, user.SenhaHash))
            throw new DomainException("Usuário ou senha inválidos");


        if (!user.PodeLogar())
            throw new DomainException("Usuário inativo");


        var token = _jwtService.GerarToken(user);
        var refresh = _jwtService.GerarRefreshToken();


        await _usuarioService.SalvarRefreshTokenAsync(new RefreshToken
        {
            UsuarioId = user.UsuarioId,
            Token = refresh,
            ExpiraEm = DateTime.Now.AddDays(7)
        });

        return new AuthResponseDto(token, refresh);
    }
}
