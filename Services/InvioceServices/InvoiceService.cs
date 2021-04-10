using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vn.edu.payment.qr.DTOs;
using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services.InvioceServices
{
    public class InvoiceService : ContextService, IInvoice
    {
        public InvoiceService(databaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<long> AddInvoice(InvoiceDTO invoice)
        {
            try
            {
                var Invoice = new Invoice();
                Invoice.Name = invoice.Name;
                Invoice.TotalMoney = invoice.TotalMoney;
                Invoice.CreateAt = invoice.CreateAt;
                Invoice.CustomerAddress = invoice.CustomerAddress;
                Invoice.Phone = invoice.Phone;
                Invoice.Email = invoice.Email;
                Invoice.CustomerId = invoice.CustomerId;
                Invoice.Status = false;

                databaseContext.Invoices.Add(Invoice);
                await databaseContext.SaveChangesAsync();

                long InvoiceId = Invoice.Id;
                foreach (var item in invoice.order_item)
                {
                    var invoiceDetail = new InvoiceDetail();
                    invoiceDetail.InvoiceId = InvoiceId;
                    invoiceDetail.ProductId = item.ProductId;
                    invoiceDetail.Amount = item.Amount;
                    invoiceDetail.Price = item.Price;

                    databaseContext.InvoiceDetails.Add(invoiceDetail);
                    await databaseContext.SaveChangesAsync();
                }
                return InvoiceId;
            }
            catch
            {
                return -1;
            }
            
        }

        public async Task<IList<Invoice>> GetInvioceById(long id)
        {
            return await databaseContext.Invoices.Where(x => x.CustomerId == id).ToListAsync();
        }

        public async Task<IList<InvoiceDetailDTO>> GetInvoiceDetailById(long id)
        {
            var invoiceDetail = await databaseContext.InvoiceDetails.Where(x => x.InvoiceId == id).Join(
                databaseContext.Products,
                d => d.ProductId,
                p => p.Id,
                (d, p) => new { d, p }
                ).Select(cp => new InvoiceDetailDTO
                {
                    nameProduct = cp.p.Name,
                    imageProduct = cp.p.Image,
                    Amount = cp.d.Amount,
                    Price = cp.d.Price
                }).ToListAsync();
            return invoiceDetail;
        }
    }
}
