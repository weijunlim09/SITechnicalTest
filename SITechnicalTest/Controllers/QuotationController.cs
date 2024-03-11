using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITechnicalTest.Interfaces;
using SITechnicalTest.Services;
using SITechnicalTest_API.Models;

namespace SITechnicalTest.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly ISupplierService _supplierService;
        public QuotationController(IQuotationService quotationService, ISupplierService supplierService)
        {
            _supplierService = supplierService;
            _quotationService = quotationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Quotation> quotations = await _quotationService.Get();
            return View(quotations);
        }
        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateQuotation()
        {
            List<Supplier> suppliers = await _supplierService.Get();
            ViewBag.Suppliers = suppliers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuotation(Quotation newQuotation)
        {
            bool isSuccess = await _quotationService.Create(newQuotation);
            if (isSuccess) { return RedirectToAction("Index"); }
            return View();
        }
        #endregion

        #region Preview
        [HttpGet]
        public async Task<IActionResult> Preview(int QuotationId)
        {
            Quotation quotation = await _quotationService.GetByID(QuotationId);
            return View(quotation);
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Edit(int QuotationId)
        {
            Quotation quotation = await _quotationService.GetByID(QuotationId);
            ViewBag.Suppliers = await _supplierService.Get();
            return View(quotation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Quotation updatedQuotation)
        {
            bool isSuccess = await _quotationService.Update(updatedQuotation);
            if (isSuccess) return RedirectToAction("Index");
            return View(updatedQuotation);
        }

        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Remove(int QuotationId)
        {
            Quotation quotation = await _quotationService.GetByID(QuotationId);
            return View(quotation);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Quotation toBeRemovedQuotation)
        {
            bool isSuccess = await _quotationService.Delete(toBeRemovedQuotation);
            if (isSuccess) return RedirectToAction("Index");
            return View(toBeRemovedQuotation);
        } 
        #endregion
    }
}
