using Gestao.Cadastro.Digital.Application.Commands.Auditoria.InserirDadosAuditoriaCommand;
using Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarAuditoriaPorLoginQuery;
using Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarAuditoriaPorUsuarioIdQuery;
using Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarDadosAuditoriaPorIdQuery;
using MediatR;
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

    /// <summary>
    /// Endpoint para retornar auditoria a partir do seu Id
    /// </summary>
    /// <param name="auditoriaId"></param>
    /// <returns></returns>
    [HttpGet("{auditoriaId}")]
    public async Task<IActionResult> BuscarAuditoriaPorId(string auditoriaId)
    {
        var result = await _mediator.Send(new BuscarDadosAuditoriaPorIdQuery(auditoriaId));
        return Ok(result);
    }

    /// <summary>
    /// Endpoint para retornar uma lista de auditorias pelo id do usuário
    /// </summary>
    /// <param name="usuarioId"></param>
    /// <returns></returns>
    [HttpGet("{usuarioId:long}/usuario")]
    public async Task<IActionResult> BuscarAuditoriasPorUsuarioId(long usuarioId)
    {
        var result = await _mediator.Send(new BuscarAuditoriaPorUsuarioIdQuery(usuarioId));
        return Ok(result);
    }

    /// <summary>
    /// Endpoint para retornar uma lista de auditorias pelo login do usuário
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpGet("{login}/login")]
    public async Task<IActionResult> BuscarAuditoriasPeloLoginUsuario(string login)
    {
        var result = await _mediator.Send(new BuscarAuditoriaPorLoginQuery(login));
        return Ok(result);
    }
}