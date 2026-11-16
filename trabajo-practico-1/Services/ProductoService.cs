using trabajo_practico_1.Data;
using trabajo_practico_1.Models;

namespace trabajo_practico_1.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        // ASP.NET Core nos inyecta el Repository
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> ObtenerTodos()
        {
            return _productoRepository.ObtenerTodos();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productoRepository.ObtenerPorId(id);
        }
    }
}