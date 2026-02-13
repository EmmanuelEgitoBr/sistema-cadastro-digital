using Gestao.Cadastro.Digital.Application.Commands.Auditoria.InserirDadosAuditoriaCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.Cadastro.Digital.Api.Controllers;

[Route("api/auditoria")]
[ApiController]
public class AuditoriaController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuditoriaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint para inserir dados de auditoria.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> InserirDadosAuditoria([FromBody] InserirDadosAuditoriaCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}