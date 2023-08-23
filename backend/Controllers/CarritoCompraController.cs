using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/carrito-compra")]
    public class CarritoCompraController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public CarritoCompraController(IConfiguration configuration)
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
                var result = CarritoCompraService.GetAll<CarritoCompra>();
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
                var result = CarritoCompraService.GetOne<CarritoCompra>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Store(CarritoCompra carritoCompra)
        {
            try
            {
                var result = CarritoCompraService.Store(carritoCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(CarritoCompra carritoCompra, int id)
        {
            try
            {
                var result = CarritoCompraService.Update(carritoCompra, id);
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
                var result = CarritoCompraService.Delete(id);
                return Ok(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}