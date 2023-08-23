using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/detalle-carrito")]
    public class DetalleCarritoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public DetalleCarritoController(IConfiguration configuration)
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
                var result = DetalleCarritoService.GetAll<DetalleCarrito>();
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
                var result = DetalleCarritoService.GetOne<DetalleCarrito>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Store(DetalleCarrito detalleCarrito)
        {
            try
            {
                var result = DetalleCarritoService.Store(detalleCarrito);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(DetalleCarrito detalleCarrito, int id)
        {
            try
            {
                var result = DetalleCarritoService.Update(detalleCarrito, id);
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
                var result = DetalleCarritoService.Delete(id);
                return Ok(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}