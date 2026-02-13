using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.Auditoria.InserirDadosAuditoriaCommand
{
    public record InserirDadosAuditoriaCommand(AuditoriaDto Auditoria) : IRequest<string>;
}
