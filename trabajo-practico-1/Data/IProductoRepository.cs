using trabajo_practico_1.Models;

namespace trabajo_practico_1.Data
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}