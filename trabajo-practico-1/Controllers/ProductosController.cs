using Microsoft.AspNetCore.Mvc;

namespace trabajo_practico_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("El controller de productos funciona");
        }
    }
}