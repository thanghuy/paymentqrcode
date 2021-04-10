using System;
using BC = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using vn.edu.payment.qr.Models;
using Microsoft.EntityFrameworkCore;

namespace vn.edu.payment.qr.Services.UserServices
{
    public class UserService : ContextService, IUser
    {
        public UserService(databaseContext dbContext) : base(dbContext)
        {
        }


        public async Task<Customer> GetUserById(long idUser)
        {
            return await databaseContext.Customers.FindAsync(idUser);
        }

        public async Task<Customer> Login(string username, string password)
        {
            var hashpass = HashPassword(password);
            var result = await databaseContext.Customers
                         .Where(c => c.Username.Equals(username))
                         .FirstOrDefaultAsync();
            if(result is null)
            {
                return null;
            }
            else
            {
                bool validatepass = BCrypt.Net.BCrypt.Verify(password, result.Password);
                if (validatepass)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<long> Resigter(Customer customer)
        {
            var result = await databaseContext.Customers
                         .Where(c => c.Username.Equals(customer.Username)).FirstOrDefaultAsync();
            if(result is not null)
            {
                return -1;
            }
            else
            {
                customer.Password = HashPassword(customer.Password);
                databaseContext.Add(customer);
                int row = await databaseContext.SaveChangesAsync();
                if (row == 0)
                {
                    return -1;
                }
                else
                {
                    return customer.Id;
                }
            }
        }
        public string HashPassword(string password)
        {

            string hash = BC.HashPassword(password);
            return hash;
        }
    }
}
