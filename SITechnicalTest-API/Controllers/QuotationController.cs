using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Data;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly ILogger<QuotationController> _logger;
        private readonly ApplicationDbContext _db;

        public QuotationController(ILogger<QuotationController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Quotation> quotations = _db.Quotations.ToList();
            return Ok(quotations);
        }

        [HttpGet("id")]
        public IActionResult GetByID([FromQuery] int id)
        {
            Quotation? quotation = _db.Quotations.Find(id);
            if (quotation == null) return NotFound();
            return Ok(quotation);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Quotation quotation)
        {
            _db.Quotations.Add(quotation);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Quotation updatedQuotation)
        {
            Quotation? existingQuotation = _db.Quotations.Find(id);

            if (existingQuotation == null) return NotFound();
            existingQuotation.Product = updatedQuotation.Product;   
            existingQuotation.CostPerUnit = updatedQuotation.CostPerUnit;
            existingQuotation.SupplierId = updatedQuotation.SupplierId; 
            _db.Quotations.Update(existingQuotation);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            if (id < 0) return BadRequest();
            Quotation? existingQuotation = _db.Quotations.Find(id);
            if (existingQuotation == null) return NotFound(id);
            _db.Quotations.Remove(existingQuotation);
            _db.SaveChanges();
            return NoContent();
        }

    }
}
