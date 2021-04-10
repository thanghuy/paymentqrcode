using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vn.edu.payment.qr.DTOs;
using vn.edu.payment.qr.Models;
using vn.edu.payment.qr.Services.InvioceServices;

namespace vn.edu.payment.qr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly databaseContext _context;
        private readonly IInvoice _invoiceService;

        public InvoicesController(databaseContext context, IInvoice invoice)
        {
            _context = context;
            _invoiceService = invoice;
        }

        // GET: api/invoicedetails/1
        [HttpGet]
        [Route("/api/invoicedetails/{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoicesDetail(long id)
        {
            var result = _invoiceService.GetInvoiceDetailById(id);
            if(result is null)
            {
                return BadRequest();
            }
            return Ok(new { status = true , data = result } );
        }

        [HttpGet]
        [Route("/api/invoicesOne/{id}")]
        public async Task<ActionResult<Invoice>> InvoicesOne(long id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }
        // GET: api/Invoices/5
        [HttpGet("{idCustomer}")]
        public async Task<ActionResult<Invoice>> GetInvoice(long idCustomer)
        {
            var invoice = await _invoiceService.GetInvioceById(idCustomer);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(new { status = true, data = invoice });
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(long id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice([FromBody] InvoiceDTO invoice)
        {
            /*_context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();*/
            long result = await _invoiceService.AddInvoice(invoice);
            if (result == -1)
            {
                return BadRequest();
            }

            return Ok(new { status = true, InvoiceId = result});
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(long id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(long id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
