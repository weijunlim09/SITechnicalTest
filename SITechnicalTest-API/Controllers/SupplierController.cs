using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Data;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Supplier> suppliers = await _db.Suppliers.ToListAsync();
            return Ok(suppliers);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByID([FromQuery] int id)
        {
            Supplier? supplier = await _db.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Supplier supplier)
        {
            if (supplier == null) return BadRequest();
            _db.Suppliers.Add(supplier);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] Supplier supplier)
        {
            if (supplier == null) return BadRequest();
            Supplier? sup = await _db.Suppliers.FindAsync(id);
            if (sup == null) return NotFound();
            _db.Update(supplier);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch]
        public async Task<IActionResult> Patch([FromQuery] int id, [FromBody] Supplier supplier)
        {
            if (supplier == null) return BadRequest();
            Supplier? sup = await _db.Suppliers.FindAsync(id);
            if (sup == null) return NotFound();

            if (supplier.Name != null) sup.Name = supplier.Name;
            if (supplier.Email != null) sup.Email = supplier.Email;
            if (supplier.CountryCode != null) sup.CountryCode = supplier.CountryCode;
            if (supplier.Quotations != null) sup.Quotations = supplier.Quotations;

            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (id < 0) return BadRequest();

            Supplier? sup = await _db.Suppliers.FindAsync(id);
            if (sup == null) return NotFound(id);
            _db.Suppliers.Remove(sup);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }


}
