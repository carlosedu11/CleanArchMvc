using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id:int}", Name =("GetProduct"))]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            if (id == null) return BadRequest($"{id} invalid");

            var product = await _productService.GetById(id);

            if(product == null) return NotFound("Product not found");

            return Ok(product); 
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest("Invalid data");

            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id}, productDTO);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id) return BadRequest("Invalid data");

            if (productDTO == null) return NotFound("Product not found");

            await _productService.Update(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) return BadRequest();

            var product = await _productService.GetById(id);

            if (product == null) return NotFound("Product not found");

            await _productService.Remove(id);

            return Ok(product);

        }

    }
}
