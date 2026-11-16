using Microsoft.AspNetCore.Mvc;
using trabajo_practico_1.Services;

namespace trabajo_practico_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        // Constructor: ASP.NET Core nos "inyecta" el Service acá
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET /api/productos
        [HttpGet]
        public IActionResult Get()
        {
            var productos = _productoService.ObtenerTodos();
            return Ok(productos);
        }

        // GET /api/productos/5
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var producto = _productoService.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }
    }
}