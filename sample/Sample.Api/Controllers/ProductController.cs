using Microsoft.AspNetCore.Mvc;
using Sample.Core.Products;
using Sample.Core.Users;
using System.Collections.Generic;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IUserManager _userManager;

        public ProductController(IProductManager productManager, IUserManager userManager)
        {
            _productManager = productManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productManager.GetAll();
        }

        [HttpGet("current")]
        public string CurrentUser()
        {
            return _userManager.CurrentUser();
        }
    }
}
