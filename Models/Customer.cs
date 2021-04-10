using System;
using System.Collections.Generic;

#nullable disable

namespace vn.edu.payment.qr.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
