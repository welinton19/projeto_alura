using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Interfaces;
using Projeto_Alura.Application.Services;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUsersServices _usersServices;
    private readonly ILogger<UserController> _logger;
    private readonly ITokenServices _tokenServices;

    public UserController(IUsersServices usersServices, ILogger<UserController> logger, ITokenServices tokenServices)
    {
        _usersServices = usersServices;
        _logger = logger;
        _tokenServices = tokenServices;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUsersDTO createUsersDTO)
    {
        try
        {
            var user = await _usersServices.AddUsersAsync(createUsersDTO);
            return Ok(new { user, message = "Usuário registrado com sucesso" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar usuário");
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginUsersDTO)
    {
        
        var user = await _usersServices.LoginAsync(loginUsersDTO.Email, loginUsersDTO.Password);
        if (user == null)
            return Unauthorized(new { message = "Email ou senha inválidos!" });

        
        var token = await _tokenServices.GerartToken(user.Email, user.Role.ToString());

        Response.Cookies.Append("access_token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddMinutes(60)
        });

        return Ok(new { message = "Login realizado com sucesso!", token });
    }

    [HttpGet("getall")]
    [Authorize(Roles = "Admin,Instructor")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUsersDTO getAllUsersDTO)
    {
        try
        {
            var users = await _usersServices.GetAllAsync(getAllUsersDTO);
            return Ok(new { users });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar usuários");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("getbyid/{id}")]
    [Authorize(Roles = "Admin,Instructor")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        try
        {
            var user = await _usersServices.GetUsersById(new GetIdUsersDTO { Id = id });
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUsersDTO updateUsersDTO)
    {
        var user = await _usersServices.UpdateUsersAsync(updateUsersDTO);
        return Ok(new { user, message = "Usuário atualizado com sucesso" });
        
    }
    [HttpDelete("delete")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromBody] DeleteUsersDTO deleteUsersDTO)
    {
        try
        {
            await _usersServices.DeleteUsersAsync(deleteUsersDTO);
            return Ok(new { message = "Usuário excluído com sucesso" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir usuário");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("logout")]
    public IActionResult Lgout()
    {
        Response.Cookies.Delete("access_token");
        return Ok(new { message = "Logout realizado com sucesso" });
    }
}
