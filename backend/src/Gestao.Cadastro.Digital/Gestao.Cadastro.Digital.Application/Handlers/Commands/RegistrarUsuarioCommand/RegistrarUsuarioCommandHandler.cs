using Gestao.Cadastro.Digital.Application.Interfaces.Auth;
using Gestao.Cadastro.Digital.Domain.Entities.Auth;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Command = Gestao.Cadastro.Digital.Application.Commands.Auth.RegistrarUsuarioCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.RegistrarUsuarioCommand;

public class RegistrarUsuarioCommandHandler : IRequestHandler<Command.RegistrarUsuarioCommand, long>
{
    private readonly IUsuarioService _usuarioService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<RegistrarUsuarioCommandHandler> _logger;

    public RegistrarUsuarioCommandHandler(IUsuarioService usuarioService,
        IPasswordHasher passwordHasher,
        ILogger<RegistrarUsuarioCommandHandler> logger)
    {
        _usuarioService = usuarioService;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }

    public async Task<long> Handle(Command.RegistrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando o processo de registro do usuário: {Login}", request.Login);

        try
        {
            var usuarioExistente = await _usuarioService.ObterPorLoginAsync(request.Login);

            if (usuarioExistente != null)
            {
                _logger.LogWarning("O login {Login} já está em uso.", request.Login);
                throw new DomainException($"O login {request.Login} já está em uso.");
            }

            var senhaHash = _passwordHasher.Hash(request.Senha);
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Cpf = request.Cpf,
                Login = request.Login,
                SenhaHash = senhaHash,
                Role = request.Role
            };

            await _usuarioService.AdicionarAsync(usuario);
            await _usuarioService.SalvarAlteracoesAsync();

            _logger.LogInformation("Usuário {Login} registrado com sucesso. ID: {UsuarioId}",
                request.Login, usuario.UsuarioId);

            return usuario.UsuarioId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar o usuário {Login}", request.Login);
            throw;
        }
    }
}
