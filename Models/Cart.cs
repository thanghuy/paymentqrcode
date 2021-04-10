using System;
using System.Collections.Generic;

#nullable disable

namespace vn.edu.payment.qr.Models
{
    public partial class Cart
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? ProductId { get; set; }
        public long Amount { get; set; }
    }
}
