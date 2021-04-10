using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vn.edu.payment.qr.Services.CartServices
{
    public interface ICart
    {
        Task<Object> GetCart(long idCustomer);
        public Task<bool> AddToCart(Models.Cart cart);
        Task<bool> Delete(long idCart, long iduser);
        Task<bool> Update(long id, long? customerId, long amount);
    }
}
