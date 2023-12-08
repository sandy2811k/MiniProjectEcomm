using Microsoft.AspNetCore.Mvc;
using MiniProjectEcomm.Models;
using MiniProjectEcomm.Services;

namespace MiniProjectEcomm.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await service.GetAllProducts();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductById/{Pid}")]
        public async Task<IActionResult> Get(int Pid)
        {
            try
            {
                var model = await service.GetProductById(Pid);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "Pname,Price,ImageUrl,Cid")] Product product)
        {
            try
            {
                var result = await service.AddProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                var result = await service.UpdateProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{Pid}")]
        public async Task<IActionResult> Delete(int Pid)
        {
            try
            {
                var result = await service.DeleteProduct(Pid);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}