using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.DTOs
{
    public class CartDTO : Product
    {
        public long IdCustomer { get; set; }
        public long Amount { get; set; }
        public long IdCart { get; set; }
        public double? Price_item { get; set; }
    }
}
