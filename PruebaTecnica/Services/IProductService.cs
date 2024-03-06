using PruebaTecnica.DTO;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductosAsync();
        Task<ProductDTO> GetProductoByIdAsync(int id);
        Task<int> CreateProductoAsync(Product producto);
        Task UpdateProductoAsync(Product producto);
        Task DeleteProductoAsync(int id);
    }
}
