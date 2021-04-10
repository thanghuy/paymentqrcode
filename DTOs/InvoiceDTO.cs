using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.DTOs
{
    public class InvoiceDTO : Invoice
    {
        public List<InvoiceDetail> order_item { get; set; }
    }
}
