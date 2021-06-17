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
    public class SuppliersController : ControllerBase
    {
        private readonly misaaccoutantContext _context;

        public SuppliersController(misaaccoutantContext context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Suppliers.OrderBy(x => x.Suppliercode).ToListAsync();
        }

        //lấy thông tin nhà cung cấp, phân trang
        // GET: api/Suppliers
        [HttpGet("paging")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers(int pageNumber, int pageSize)
        {
            return await _context.Suppliers.OrderBy(x => x.Suppliercode).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // GET: api/Suppliers/supplierCode?supplierCode=NVX3
        [HttpGet("supplierCode")]
        public async Task<ActionResult<Supplier>> GetSupplierBySupplierCode(string supplierCode)
        {
            var supplier = await _context.Suppliers.SingleAsync(s => s.Suppliercode == supplierCode);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(Guid id, Supplier supplier)
        {
            if (id != supplier.Idsupplier)
            {
                return BadRequest();
            }

            _context.Entry(supplier).State = EntityState.Modified;

            if (SupplierCodeExists(id, supplier.Suppliercode))
            {
                var erroInfo = new
                {
                    devMsg = "SupplierCode duplucate!",
                    userMsg = "Mã nhà cung cấp <" + supplier.Suppliercode + "> đã tồn tại",
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
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(supplier);
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            supplier.Idsupplier = Guid.NewGuid();
            _context.Suppliers.Add(supplier);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SupplierExists(supplier.Idsupplier))
                {
                    return Conflict();
                }
                else if (SupplierCodeExists(supplier.Suppliercode))
                {
                    var erroInfo = new
                    {
                        devMsg = "SupplierCode duplucate!",
                        userMsg = "Mã nhà cung cấp <" + supplier.Suppliercode + "> đã tồn tại",
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

            CreatedAtAction("GetSupplier", new { id = supplier.Idsupplier }, supplier);
            return Ok(supplier);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // tìm kiếm nhà cung cấp theo các cột
        // GET: api/Suppliers/search?keyword=nv&pageNumber=1&pageSize=10
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Supplier>>> SearchSupplier(string keyword, int pageNumber, int pageSize)
        {
            keyword = keyword.ToLower();
            var supplier = await _context.Suppliers.Where(
            s => s.Suppliercode.ToLower().Contains(keyword) ||
            s.Suppliername.ToLower().Contains(keyword) ||
            s.Supplieraddress.ToLower().Contains(keyword) ||
            s.Suppliertaxcode.ToLower().Contains(keyword) ||
            s.Identitycardnumber.ToLower().Contains(keyword)).OrderBy(x => x.Suppliercode).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return supplier;
        }

        // số bản ghi nhà cung cấp trong tìm kiếm
        // GET: api/Suppliers/lengthSearch?keyword=nv
        [HttpGet("lengthSearch")]
        public IActionResult GetLengthSuppliers(string keyword)
        {
            keyword = keyword.ToLower();
            var rowEffects = _context.Suppliers.Where(
            s => s.Suppliercode.ToLower().Contains(keyword) ||
            s.Suppliername.ToLower().Contains(keyword) ||
            s.Supplieraddress.ToLower().Contains(keyword) ||
            s.Suppliertaxcode.ToLower().Contains(keyword) ||
            s.Identitycardnumber.ToLower().Contains(keyword)).Count();
            
            return Ok(rowEffects);
        }

        // số bản ghi nhà cung cấp
        // GET: api/Suppliers/length
        [HttpGet("length")]
        public IActionResult GetLengthSearchSuppliers()
        {
            var rowEffects = _context.Suppliers.Count();
            return Ok(rowEffects);
        }

        // mã nhà cung cấp mới
        // GET: api/Suppliers/newsuppliercode
        [HttpGet("newsuppliercode")]
        public IActionResult GetNewSupplierCode()
        {
            var rowEffects = _context.Suppliers.Max(s => s.Suppliercode);
            if (rowEffects == null)
            {
                rowEffects = "NCC0001";
                return Ok(rowEffects);
            }
            var prefix = Regex.Match(rowEffects, "^\\D+").Value;
            var number = Regex.Replace(rowEffects, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            return Ok(newString);
        }

        private bool SupplierExists(Guid id)
        {
            return _context.Suppliers.Any(e => e.Idsupplier == id);
        }

        private bool SupplierCodeExists(string suppliercode)
        {
            return _context.Suppliers.Any(e => e.Suppliercode == suppliercode);
        }

        private bool SupplierCodeExists(Guid id, string suppliercode)
        {
            return _context.Suppliers.Any(e => (e.Suppliercode == suppliercode && e.Idsupplier != id));
        }
    }
}
