using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly misaaccoutantContext _context;

        public PaymentsController(misaaccoutantContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(Guid id, Payment payment)
        {
            if (id != payment.Idpayment)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            payment.Idpayment = Guid.NewGuid();
            _context.Payments.Add(payment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentExists(payment.Idpayment))
                {
                    return Conflict();
                }
                else if (PaymentNumberExists(payment.Paymentnumber))
                {
                    var erroInfo = new
                    {
                        devMsg = "Paymentnumber duplucate!",
                        userMsg = "Số phiếu chi <" + payment.Paymentnumber + "> đã tồn tại",
                        errorCode = "misa-001",
                        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                    };

                    return BadRequest(erroInfo);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPayment", new { id = payment.Idpayment }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // mã phiếu chi mới
        // GET: api/Suppliers/newpaymentnumber
        [HttpGet("newpaymentnumber")]
        public IActionResult GetNewSupplierCode()
        {
            var rowEffects = _context.Payments.Max(p => p.Paymentnumber);
            if (rowEffects == null)
            {
                rowEffects = "PC0001";
                return Ok(rowEffects);
            }
            var prefix = Regex.Match(rowEffects, "^\\D+").Value;
            var number = Regex.Replace(rowEffects, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            return Ok(newString);
        }

        private bool PaymentExists(Guid id)
        {
            return _context.Payments.Any(e => e.Idpayment == id);
        }

        //check số phiếu chi
        private bool PaymentNumberExists(string paymentNumber)
        {
            return _context.Payments.Any(e => e.Paymentnumber == paymentNumber);
        }

        //check số phiếu chi khi sửa
        private bool PaymentNumberExists(Guid id, string paymentNumber)
        {
            return _context.Payments.Any(p => p.Paymentnumber == paymentNumber && p.Idpayment != id);
        }
    }
}
