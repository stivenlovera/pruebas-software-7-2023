using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/categoria-producto")]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public CategoriaProductoController(IConfiguration configuration)
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
                var result = CategoriaProductoService.GetAll<Usuario>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetOne([FromQuery] int id)
        {
            try
            {
                var result = CategoriaProductoService.GetOne<Usuario>(id);
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
                var result = CategoriaProductoService.Store(usuarios);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(Usuario usuarios)
        {
            try
            {
                var result = CategoriaProductoService.Update(usuarios);
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
                return Ok(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}