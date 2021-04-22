using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.ProductRepos
{
    public class ProductRepository : IProductRepository
    {
        public List<string> GetAll()
        {
            return new List<string> { "ok" };
        }
    }
}
