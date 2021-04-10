using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services.ProductServices
{
    public class ProductService : ContextService, IProductService
    {
        public ProductService(databaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Product>> GetAllProduct()
        {
            return await databaseContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(long id)
        {
            return await databaseContext.Products.FindAsync(id);
        }
    }
}
