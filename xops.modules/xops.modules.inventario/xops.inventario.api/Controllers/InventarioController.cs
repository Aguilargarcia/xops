using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xops.common.Controller;
using xops.inventario.core.Dto;
using xops.inventario.core.Entities;
using xops.inventario.core.Interfaces;

namespace xops.inventario.api.Controllers
{
    public class InventarioController : BaseController
    {
        private readonly IInventarioService _service;
        public InventarioController(IInventarioService service){
            _service = service;
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductoDto productoDto){
            Producto producto = await _service.AddProducto(productoDto);
            return Ok(producto);
        }

        [Route("UpdateProducto")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductoDto productoDto){
            Producto producto = await _service.UpdateProducto(productoDto);
            return Ok(producto);
        }

        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts(){
            IReadOnlyCollection<ProductoDto> productos = await _service.GetProductos();
            return Ok(productos);
        }

        [Route("DeleteProduct/{productId}")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Guid productId){
            await _service.DeleteProductById(productId);
            return Ok();
        }


    }
}
