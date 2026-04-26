using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Interfaces;

namespace Projeto_Alura.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatriculasController : ControllerBase
{
    private readonly IMatriculasServices _matriculasServices;

    public MatriculasController(IMatriculasServices matriculasServices)
    {
        _matriculasServices = matriculasServices;
    }

    [HttpPost("criar")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CriarMatricula([FromBody] CreateMatriculasDTO createMatriculasDTO)
    {
        try
        {
            var matriculaCriada = await _matriculasServices.CreateMatriculasAsync(createMatriculasDTO);
            return Ok(matriculaCriada);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getall")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllMatriculas([FromQuery] GetAllMatriculasDTO getAllMatriculasDTO)
    {
        try
        {
            var matriculas = await _matriculasServices.GetMatriculasAsync(getAllMatriculasDTO);
            return Ok(matriculas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetMatriculaById([FromRoute] long id)
    {
        try
        {
            var matricula = await _matriculasServices.GetById(new GetMatriculasByIdDTO { Id = id });
            if (matricula == null)
                return NotFound(new { message = "Matrícula não encontrada" });
            return Ok(matricula);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateMatricula([FromBody] UpdateMatriculasDTO updateMatriculasDTO)
    {
        try
        {
            var matricula = await _matriculasServices.UpdateMatriculasAsync( updateMatriculasDTO);
            return Ok(matricula);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMatricula([FromBody] DeleteMatriculasDTO deleteMatriculasDTO)
    {
        try
        {
            await _matriculasServices.DeleteMatriculasAsync(deleteMatriculasDTO);
            return Ok(new { message = "Matrícula excluída com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
