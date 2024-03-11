using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SITechnicalTest.Interfaces;
using SITechnicalTest_API.Models;

namespace SITechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ISupplierService _supplierService;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env, ISupplierService supplierService)
        {
            _logger = logger;
            _environment = env;
            _supplierService = supplierService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Supplier> suppliers = await _supplierService.Get();
            return View(suppliers);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Supplier());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier newSupplier)
        {
            bool isSuccess = await _supplierService.Create(newSupplier);
            if (isSuccess) { return RedirectToAction("Index"); }
            return View();
        }

        #endregion
        
        #region Preview

        [HttpGet]
        public async Task<IActionResult> Preview(int id)
        {
            Supplier supplier = await _supplierService.GetByID(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Preview()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            Supplier supplier = await _supplierService.GetByID(id);
            return View(supplier);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Supplier supplier)
        {
            bool isSuccess = await _supplierService.Update(supplier);
            if (isSuccess) return RedirectToAction("Index");
            return View(supplier);
        }

        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Supplier supplier = await _supplierService.GetByID(id);
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Supplier supplier)
        {
            bool isSuccess = await _supplierService.Delete(supplier);
            if (isSuccess) return RedirectToAction("Index");
            return View(supplier);
        }

        #endregion
        
        public ActionResult ExportToCSV()
        {
            return RedirectToAction("Index", "Home");
        }

        private void WriteDataToSheet<T>(ExcelWorksheet worksheet, List<T> data)
        {
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
