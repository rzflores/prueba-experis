using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productoService;

        public ProductsController(IProductService productoService)
        {
            _productoService = productoService;
        }

        // GET api/productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductos()
        {
            try
            {
                var productos = await _productoService.GetAllProductosAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // GET api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductoById(int id)
        {
            try
            {
                var producto = await _productoService.GetProductoByIdAsync(id);
                if (producto != null)
                    return Ok(producto);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // POST api/productos
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProducto(Product producto)
        {
            try
            {
                var nuevoProductoId = await _productoService.CreateProductoAsync(producto);
                return CreatedAtAction(nameof(GetProductoById), new { id = nuevoProductoId }, producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // PUT api/productos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProducto(int id, Product producto)
        {
            try
            {
                var productoExistente = await _productoService.GetProductoByIdAsync(id);
                if (productoExistente == null)
                    return NotFound();

                producto.Id = id;
                await _productoService.UpdateProductoAsync(producto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // DELETE api/productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            try
            {
                var productoExistente = await _productoService.GetProductoByIdAsync(id);
                if (productoExistente == null)
                    return NotFound();

                await _productoService.DeleteProductoAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
