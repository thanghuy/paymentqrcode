using System;
using System.Collections.Generic;

#nullable disable

namespace vn.edu.payment.qr.Models
{
    public partial class InvoiceDetail
    {
        public long Id { get; set; }
        public long? InvoiceId { get; set; }
        public long? ProductId { get; set; }
        public long Amount { get; set; }
        public double Price { get; set; }
    }
}
