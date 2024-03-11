using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Core;
using SITechnicalTest_API.Data;
using SITechnicalTest_API.Models;

namespace SITechnicalTest_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Supplier> suppliers = await _unitOfWork.SupplierRepository.GetAll();
            return Ok(suppliers);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromQuery] int id)
        {
            Supplier? supplier = await _unitOfWork.SupplierRepository.GetByID(id);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Supplier supplier)
        {
            await _unitOfWork.SupplierRepository.Add(supplier);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Supplier updatedSupplier)
        {
            await _unitOfWork.SupplierRepository.Update(updatedSupplier);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (id < 0) return BadRequest();
            Supplier? supplier = await _unitOfWork.SupplierRepository.GetByID(id);
            if (supplier == null) return NotFound();
            await _unitOfWork.SupplierRepository.Delete(supplier);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
