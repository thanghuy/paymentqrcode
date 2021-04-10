using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.DTOs;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services.CartServices
{
    public class CartService : ContextService, ICart
    {
        public CartService(databaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddToCart(Cart cart)
        {
            var cart_item = databaseContext.Carts.AsEnumerable<Cart>();
            var _cart = cart_item.Where(x => x.ProductId == cart.ProductId && x.CustomerId == cart.CustomerId).FirstOrDefault();
            if (_cart == null)
            {
                databaseContext.Add(cart);
            }
            else
            {
                _cart.Amount += cart.Amount;
            }
            //
            return await databaseContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(long idCart, long iduser)
        {
            var cart_item = await databaseContext.Carts.
                                  Where(x => x.Id == idCart && x.CustomerId == iduser).FirstOrDefaultAsync();
            databaseContext.Carts.Remove(cart_item);
            return await databaseContext.SaveChangesAsync() != 0;
        }

        public async Task<object> GetCart(long idCustomer)
        {
            var result = await databaseContext.Carts.Where(x => x.CustomerId == idCustomer).Join(
                databaseContext.Products,
                ca => ca.ProductId,
                p => p.Id,
                (ca, p) => new { ca, p }
                ).Select(cp => new CartDTO()
                {
                    IdCart = cp.ca.Id,
                    IdCustomer = (long)cp.ca.CustomerId,
                    Name = cp.p.Name,
                    Amount = cp.ca.Amount,
                    Id = cp.p.Id,
                    Image = cp.p.Image,
                    Price = cp.p.Price * cp.ca.Amount,
                    CatalogId = cp.p.CatalogId,
                    Price_item = cp.p.Price
                }).ToListAsync();
            return result;
        }

        public async Task<bool> Update(long idCart, long? iduser, long Amout)
        {
            var cart_item = await databaseContext.Carts.Where(x => x.Id == idCart && x.CustomerId == iduser).FirstOrDefaultAsync();
            cart_item.Amount = Amout;
            return await databaseContext.SaveChangesAsync() != 0;
        }
    }
}
