using PruebaTecnica.Data;
using PruebaTecnica.DTO;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productoRepository;

        public ProductService(ProductRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllProductosAsync();
        }

        public async Task<ProductDTO> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);
        }

        public async Task<int> CreateProductoAsync(Product producto)
        {
            return await _productoRepository.CreateProductoAsync(producto);
        }

        public async Task UpdateProductoAsync(Product producto)
        {
            await _productoRepository.UpdateProductoAsync(producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepository.DeleteProductoAsync(id);
        }
    }
}
