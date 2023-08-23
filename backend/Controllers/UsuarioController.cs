using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuariosController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string connectionString;

    public UsuariosController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var result = UsuariosServicios.GetAll<Usuario>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        try
        {
            var result = UsuariosServicios.GetOne<Usuario>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Store(Usuario usuarios)
    {
        try
        {
            var result = UsuariosServicios.Store(usuarios);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult Update(Usuario usuarios, int id)
    {
        try
        {
            var result = UsuariosServicios.Update(usuarios, id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = UsuariosServicios.Delete(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}