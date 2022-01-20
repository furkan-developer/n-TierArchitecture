using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Business.Abstact;
using WebAPI.Entities;

namespace WebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productManager;

        public ProductController(IProductService productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = productManager.GetAll();
            if (result.Process)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(Product product)
        {
            var result = productManager.Insert(product);
            if (result.Process)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
