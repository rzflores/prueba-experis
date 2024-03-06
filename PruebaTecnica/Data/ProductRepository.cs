using Dapper;
using PruebaTecnica.DTO;
using PruebaTecnica.Models;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnica.Data
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductosAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<ProductDTO>("sp_GetAllProductos", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ProductDTO> GetProductoByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<ProductDTO>("sp_GetProductoById", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> CreateProductoAsync(Product producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameters = new
                {
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    FechaRegistro = producto.FechaRegistro
                };
                return await connection.ExecuteScalarAsync<int>("sp_CreateProducto", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateProductoAsync(Product producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int rowsAffected = await connection.ExecuteAsync("sp_UpdateProducto", producto, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int rowsAffected = await connection.ExecuteAsync("sp_DeleteProducto", new { Id = id }, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
    }
}

