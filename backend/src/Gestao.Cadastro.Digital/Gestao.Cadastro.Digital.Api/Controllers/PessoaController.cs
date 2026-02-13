using Gestao.Cadastro.Digital.Application.Commands.CriarContatoCommand;
using Gestao.Cadastro.Digital.Application.Commands.CriarEnderecoCommand;
using Gestao.Cadastro.Digital.Application.Commands.CriarPessoaFisicaCommand;
using Gestao.Cadastro.Digital.Application.Commands.CriarPessoaJuridicaCommand;
using Gestao.Cadastro.Digital.Application.Commands.InativarPessoaCommand;
using Gestao.Cadastro.Digital.Application.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.Cadastro.Digital.Api.Controllers;

[Route("api/pessoa")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IMediator _mediator;

    public PessoaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint para criar uma nova pessoa física.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>O idPessoa gerado na criação</returns>
    [HttpPost("pessoa-fisica")]
    [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CriarPessoaFisica([FromBody] CriarPessoaFisicaCommand command)
    {
        var idPessoa = await _mediator.Send(command);
        return Created($"api/pessoa/{idPessoa}",
            ApiResponse<long>.Ok(idPessoa, "Pessoa física criada com sucesso"));
    }

    /// <summary>
    /// Endpoint para criar uma nova pessoa jurídica.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>O Id da pessoa criada</returns>
    [HttpPost("pessoa-juridica")]
    [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CriarPessoaJuridica([FromBody] CriarPessoaJuridicaCommand command)
    {
        var idPessoa = await _mediator.Send(command);
        return Created($"api/pessoa/{idPessoa}",
            ApiResponse<long>.Ok(idPessoa, "Pessoa jurídica criada com sucesso"));
    }

    /// <summary>
    /// Endpoint para criar um novo contato para uma pessoa existente.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Id do contato criado</returns>
    [HttpPost("contato")]
    [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CriarContato([FromBody] CriarContatoCommand command)
    {
        var idContato = await _mediator.Send(command);
        return Created($"api/contato/{idContato}",
            ApiResponse<long>.Ok(idContato, "Contato criado com sucesso"));
    }

    /// <summary>
    /// Cria um novo endereço para uma pessoa existente.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Id do endereço criado</returns>
    [HttpPost("endereco")]
    [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CriarEndereco([FromBody] CriarEnderecoCommand command)
    {
        var idEndereco = await _mediator.Send(command);
        return Created($"api/endereco/{idEndereco}",
            ApiResponse<long>.Ok(idEndereco, "Endereço criado com sucesso"));
    }

    /// <summary>
    /// Endpoint para inativar uma pessoa existente.
    /// </summary>
    /// <param name="idPessoa"></param>
    /// <returns></returns>
    [HttpPut("{idPessoa}/inativar")]
    [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InativarPessoa(long idPessoa)
    {
        var result = await _mediator.Send(new InativarPessoaCommand(idPessoa));
        return Ok(ApiResponse<long>.Ok(result, "Pessoa inativada com sucesso"));
    }
}
