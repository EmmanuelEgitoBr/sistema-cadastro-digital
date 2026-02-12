using Gestao.Cadastro.Digital.Application.Commands.Auth.LoginCommand;
using Gestao.Cadastro.Digital.Application.Commands.Auth.RefreshTokenCommand;
using Gestao.Cadastro.Digital.Application.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gestao.Cadastro.Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint para autenticação do usuário.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(ApiResponse<AuthResponseDto>.Ok(result));
        }

        /// <summary>
        /// Endpoint para criação do refresh do token.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh(RefreshTokenCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(ApiResponse<AuthResponseDto>.Ok(result));
        }

        /// <summary>
        /// Endpoint para obter as informações do usuário autenticado.
        /// </summary>
        /// <returns></returns>
        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            return Ok(new
            {
                Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Nome = User.Identity!.Name,
                Email = User.FindFirstValue(ClaimTypes.Email)
            });
        }
    }
}
