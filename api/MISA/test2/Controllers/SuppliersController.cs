using System;
using System.Collections.Generic;
using System.Linq;
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
                        userMsg = "Mã nhà cung cấp <"+ supplier.Suppliercode + "> đã tồn tại",
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
