using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vn.edu.payment.qr.Models;
using vn.edu.payment.qr.Services.UserServices;

namespace vn.edu.payment.qr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUser _userService;

        public CustomersController(databaseContext context, IUser iUser)
        {
            _userService = iUser;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Customer>> Login(Customer customer)
        {
            
            var result = await _userService.Login(customer.Username, customer.Password);
            if (result == null)
            {
                return Ok(new { status = false, message = "login failed" });
            }
            return Ok(new { status = true, data = result });

        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("resigter")]
        public async Task<ActionResult> Create(Customer customer)
        {
            long idUser = await _userService.Resigter(customer);
            if (idUser == -1)
            {
                return Ok(new { status = false, message = "Resigter failed" });
            }
            else
            {
                var result = await _userService.GetUserById(idUser);
                return Ok(new { status = true, data = result });
            }
        }
    }
}
