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

        //lấy thông tin phiếu chi
        // GET: api/Payments/paging?pageNumber=1&pageSize=2
        [HttpGet("paging")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsPaging(int pageNumber, int pageSize)
        {
            return await _context.Payments.OrderBy(x => x.Paymentnumber).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
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

            return Ok(payment);
        }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            payment.Idpayment = Guid.NewGuid();
    
            List<Accouting> accoutings = new List<Accouting>((List<Accouting>)payment.Accoutings);

            payment.Accoutings.Clear();

            _context.Payments.Add(payment);

            //kiểm tra số phiếu chi có bị trùng hay không
            if (PaymentNumberExists(payment.Paymentnumber))
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

                else
                {
                    throw;
                }
            }

            //tạo từng accounting
            for (int i = 0; i < accoutings.Count; i++)
            {
                Accouting accouting = accoutings[i];
                accouting.Idaccounting = Guid.NewGuid();
                accouting.Idpayment = payment.Idpayment;
                _context.Accoutings.Add(accouting);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (AccoutingExists(accouting.Idaccounting))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                CreatedAtAction("GetAccouting", new { id = accouting.Idaccounting }, accouting);
            }


            CreatedAtAction("GetPayment", new { id = payment.Idpayment }, payment);
            return Ok(payment);
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

        // tìm kiếm phiếu chi theo số chứng từ, đối tượng, mã đối tượng
        // GET: api/Payments/search?keyword=nv&pageNumber=1&pageSize=10
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Payment>>> SearchPayments(string keyword, int pageNumber, int pageSize)
        {
            keyword = keyword.ToLower();
            var payments = await _context.Payments.Where(
            p => p.Paymentnumber.ToLower().Contains(keyword) ||
            p.Paymentobjectcode.ToLower().Contains(keyword) ||
            p.Paymentobjectname.ToLower().Contains(keyword)).OrderBy(x => x.Paymentnumber).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return payments;
        }


        // số bản ghi phiếu chi
        // GET: api/Payments/length
        [HttpGet("length")]
        public IActionResult GetLengthPayments()
        {
            var rowEffects = _context.Payments.Count();
            return Ok(rowEffects);
        }


        // số bản ghi phiếu chi trong tìm kiếm
        // GET: api/Payments/lengthSearch?keyword=nv
        [HttpGet("lengthSearch")]
        public IActionResult GetLengthSearchPayments(string keyword)
        {
            keyword = keyword.ToLower();
            var rowEffects = _context.Payments.Where(
            p => p.Paymentnumber.ToLower().Contains(keyword) ||
            p.Paymentobjectcode.ToLower().Contains(keyword) ||
            p.Paymentobjectname.ToLower().Contains(keyword)).Count();

            return Ok(rowEffects);
        }


        private bool PaymentExists(Guid id)
        {
            return _context.Payments.Any(e => e.Idpayment == id);
        }

        private bool AccoutingExists(Guid id)
        {
            return _context.Accoutings.Any(e => e.Idaccounting == id);
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
