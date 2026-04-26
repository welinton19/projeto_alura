using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Interfaces;
using Projeto_Alura.Application.Services;

namespace Projeto_Alura.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursosController : ControllerBase
{
    private readonly ICursosServices _services;

    public CursosController(ICursosServices services)
    {
        _services = services;
    }

    [HttpPost("criar")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CriarCurso([FromBody] CreateCursosDTO createCursosDTO)
    {
        try
        {
            var cursoCriado = await _services.CreateCurosAsync(createCursosDTO);
            return Ok(cursoCriado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getall")]
    
    public async Task<IActionResult> GetAllCursos([FromQuery] GetAllCursosDTO getAllCursosDTO)
    {
        try
        {
            var cursos = await _services.GetAllCursosAsync(getAllCursosDTO);
            return Ok(cursos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCursoById([FromRoute] long id)
    {
        try
        {
            var curso = await _services.GetCursosByIdAsync(new GetCursosByIdDTO { Id = id });
            if (curso == null)
                return NotFound(new { message = "Curso não encontrado" });
            return Ok(curso);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizar")]
    [Authorize(Roles = "Admin, Instructor")]
    public async Task<IActionResult> UpdateCurso([FromBody] UpdateCursosDTO updateCursosDTO)
    {
        try
        {
            var curso = await _services.UpdateCursosAsync(updateCursosDTO);
            return Ok(curso);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCurso([FromBody] DeleteCursosDTO deleteCursosDTO)
    {
        try
        {
            await _services.DeleteCursosAsync(deleteCursosDTO);
            return Ok(new { message = "Curso excluído com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
