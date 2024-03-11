using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Core;
using SITechnicalTest_API.Data;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            List<Quotation> quotations = await _unitOfWork.QuotationRepository.GetAll();
            foreach (Quotation quotation in quotations)
            {
                quotation.Supplier = await _unitOfWork.SupplierRepository.GetByID(quotation.SupplierId);
            }
            return Ok(quotations);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromQuery] int id)
        {
            Quotation? quotation = await _unitOfWork.QuotationRepository.GetByID(id);
            if (quotation == null) return NotFound();
            quotation.Supplier = await _unitOfWork.SupplierRepository.GetByID(quotation.SupplierId);
            return Ok(quotation);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Quotation quotation)
        {
            await _unitOfWork.QuotationRepository.Add(quotation);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Quotation updatedQuotation)
        {
            await _unitOfWork.QuotationRepository.Update(updatedQuotation);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (id < 0) return BadRequest();
            Quotation? quoatation = await _unitOfWork.QuotationRepository.GetByID(id);
            if (quoatation == null) return NotFound();
            await _unitOfWork.QuotationRepository.Delete(quoatation);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}
