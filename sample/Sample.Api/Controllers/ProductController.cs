using Microsoft.AspNetCore.Mvc;
using Sample.Core.Products;
using System.Collections.Generic;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productManager.GetAll();
        }
    }
}
