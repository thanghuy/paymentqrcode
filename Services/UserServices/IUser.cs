using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services.UserServices
{
    public interface IUser
    {
        Task<Customer> Login(string username, string password);
        Task<long> Resigter(Customer customer);
        Task<Customer> GetUserById(long idUser);
    }
}
