using System.Data;
using Microsoft.Data.SqlClient;
using trabajo_practico_1.Models;

namespace trabajo_practico_1.Data
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        // Recibe la configuración (appsettings.json) por Inyección de Dependencias
        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Programacion3")
                ?? throw new InvalidOperationException("Falta la Connection String 'Programacion3'.");
        }

        public List<Producto> ObtenerTodos()
        {
            var productos = new List<Producto>();
            const string sql = "SELECT Id, Nombre, Precio, Stock FROM Productos";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(MapearProducto(reader));
            }

            return productos;
        }

        public Producto? ObtenerPorId(int id)
        {
            const string sql = "SELECT Id, Nombre, Precio, Stock FROM Productos WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return MapearProducto(reader);
            }

            return null;
        }

        // Convierte una fila de SQL Server en un objeto Producto
        private static Producto MapearProducto(SqlDataReader reader)
        {
            return new Producto
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombre = Convert.ToString(reader["Nombre"]) ?? string.Empty,
                Precio = Convert.ToDecimal(reader["Precio"]),
                Stock = Convert.ToInt32(reader["Stock"])
            };
        }
    }
}