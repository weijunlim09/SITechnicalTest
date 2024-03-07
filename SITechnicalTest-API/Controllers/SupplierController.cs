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

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            List<Supplier> suppliers = _db.Suppliers.ToList();
            return Ok(suppliers);
        }

        [HttpGet("GetByID")]
        public IActionResult GetByID([FromQuery] int id)
        {
            Supplier? supplier = _db.Suppliers.Find(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Supplier supplier)
        {
            _db.Suppliers.Add(supplier);
            _db.SaveChanges();
            return NoContent();
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Supplier updatedSupplier)
        {
            Supplier? existingSupplier = _db.Suppliers.Find(updatedSupplier.Id);

            if (existingSupplier == null) return NotFound();
            existingSupplier.Name = updatedSupplier.Name;
            existingSupplier.Email = updatedSupplier.Email;
            existingSupplier.CountryCode = updatedSupplier.CountryCode;
            _db.Suppliers.Update(existingSupplier);
            _db.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            if (id < 0) return BadRequest();
            Supplier? sup = _db.Suppliers.Find(id);
            if (sup == null) return NotFound(id);
            _db.Suppliers.Remove(sup);
            _db.SaveChanges();
            return NoContent();
        }
    }


}
