using System;
using System.Collections.Generic;

#nullable disable

namespace vn.edu.payment.qr.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? CatalogId { get; set; }
        public long Amount { get; set; }
        public double? Price { get; set; }
        public string Image { get; set; }
    }
}
