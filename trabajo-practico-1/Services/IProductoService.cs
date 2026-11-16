using trabajo_practico_1.Models;

namespace trabajo_practico_1.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}