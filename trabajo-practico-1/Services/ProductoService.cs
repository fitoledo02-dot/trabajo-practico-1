using trabajo_practico_1.Models;

namespace trabajo_practico_1.Services
{
    public class ProductoService : IProductoService
    {
        // Datos de prueba (todavía NO usamos la base de datos)
        private readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Teclado", Precio = 45000m, Stock = 15 },
            new Producto { Id = 2, Nombre = "Mouse",   Precio = 18500.50m, Stock = 30 }
        };

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }
    }
}