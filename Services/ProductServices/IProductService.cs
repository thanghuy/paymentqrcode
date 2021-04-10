using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services.ProductServices
{
    public interface IProductService
    {
        Task<Product> GetProductById(long id);
        Task<IList<Product>> GetAllProduct();
    }
}
