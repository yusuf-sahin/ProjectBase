using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Provera.Pamera.API.ViewModels;
using Provera.Pamera.Business.Abstract;
using Provera.Pamera.Model.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Provera.Pamera.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }



        public async Task<ActionResult<List<ProductVM>>> GetAsync()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IList<ProductVM>>(products));

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductVM>(product));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ProductVM>> AddAsync(ProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(productVM);

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = product.Id }, product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductVM>> UpdateAsync(int id, [FromBody] ProductVM productVM)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != productVM.Id)
            {
                return BadRequest();
            }
            var productToBeAUpdate = await _productService.GetByIdAsync(id);

            if (productToBeAUpdate == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(productVM);
           // product.CreatedAt = productToBeAUpdate.CreatedAt;
           //  product.CreatedBy = productToBeAUpdate.CreatedBy;
            await _productService.UpdateAsync(product);
            return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var productToBeDelete = await _productService.GetByIdAsync(id);

            if (productToBeDelete == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);

            return NoContent();
        }

    }
}

