using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
=======
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
>>>>>>> 61fd6bb9db1a379bbbfffc7aa4c61bcadfbbf639

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
<<<<<<< HEAD
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            if (id == null) return BadRequest();

            var product = await _productService.GetById(id);

            if (product == null) return BadRequest();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest();

            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
=======
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

>>>>>>> 61fd6bb9db1a379bbbfffc7aa4c61bcadfbbf639
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
<<<<<<< HEAD
            if (id != productDTO.Id) return BadRequest();

            var product = await _productService.GetById(id);

            if (product == null) return BadRequest();

            await _productService.Update(productDTO);

            return Ok(product);
=======
            if (id != productDTO.Id) return BadRequest("Invalid data");

            if (productDTO == null) return NotFound("Product not found");

            await _productService.Update(productDTO);

            return Ok(productDTO);
>>>>>>> 61fd6bb9db1a379bbbfffc7aa4c61bcadfbbf639
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
<<<<<<< HEAD
            if (id == null) return BadRequest();    

            var product = await _productService.GetById(id);

            if (product == null) return BadRequest();
=======
            if (id == null) return BadRequest();

            var product = await _productService.GetById(id);

            if (product == null) return NotFound("Product not found");
>>>>>>> 61fd6bb9db1a379bbbfffc7aa4c61bcadfbbf639

            await _productService.Remove(id);

            return Ok(product);
<<<<<<< HEAD
        }

=======

        }
>>>>>>> 61fd6bb9db1a379bbbfffc7aa4c61bcadfbbf639

    }
}
