using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.DTOs;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services.InvioceServices
{
    public interface IInvoice
    {
        Task<long> AddInvoice(InvoiceDTO invoice);
        Task<IList<Invoice>> GetInvioceById(long id);
        Task<IList<InvoiceDetailDTO>> GetInvoiceDetailById(long id);
    }
}
