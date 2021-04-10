using System;
using System.Collections.Generic;

#nullable disable

namespace vn.edu.payment.qr.Models
{
    public partial class Invoice
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long TotalMoney { get; set; }
        public string CreateAt { get; set; }
        public string CustomerAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long? CustomerId { get; set; }
        public bool? Status { get; set; }
    }
}
