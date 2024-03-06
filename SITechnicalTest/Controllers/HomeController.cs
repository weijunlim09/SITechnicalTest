using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SITechnicalTest.Data;
using SITechnicalTest.Models;
using SITechnicalTest_API.Models;
using System.Diagnostics;

namespace SITechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private static List<Supplier> Suppliers = new List<Supplier>();
        private static List<Quotation> Quotations = new List<Quotation>();

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }

        public IActionResult Index()
        {
            List<Supplier> suppliers = _db.Suppliers.ToList();
            foreach (Supplier supplier in suppliers)
            {
                if (supplier.CountryCode == "GB")
                {
                    supplier.CountryCode = "United Kingdom";

                }
                else if (supplier.CountryCode == "JP")
                {
                    supplier.CountryCode = "Japan";
                }
            }
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DbSupplier obj)
        {
            if (obj.Name != null && obj.Email != null && obj.CountryCode != null)
            {
                _db.Suppliers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound();
            }
            DbSupplier supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Update(DbSupplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Suppliers.Update(supplier);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound();
            }
            DbSupplier supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Delete(DbSupplier supplier)
        {
            
            if (supplier == null)
            {
                return NotFound();
            }
            _db.Suppliers.Remove(supplier);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ExportToCSV()
        {
            List<DbSupplier> suppliers = _db.Suppliers.ToList();
            List<DbQuotation> quotations = _db.Quotations.ToList();

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet supplierSheet = package.Workbook.Worksheets.Add("Supplier");
                WriteDataToSheet(supplierSheet, suppliers);

                ExcelWorksheet quotationSheet = package.Workbook.Worksheets.Add("Quotation");
                WriteDataToSheet(quotationSheet, quotations);

                string folderPath = Path.Combine(_environment.WebRootPath, "csv");
                string filePath = Path.Combine(folderPath, "SI-Technical-Test.xlsx");
                Directory.CreateDirectory(folderPath); 
                System.IO.File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
            return RedirectToAction("Index", "Home");
        }

        private void WriteDataToSheet<T>(ExcelWorksheet worksheet, List<T> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                var item = data[i];
                if (data is List<DbSupplier>)
                {
                    var supplier = item as DbSupplier;
                    worksheet.Cells[i + 1, 1].Value = supplier.Id;
                    worksheet.Cells[i + 1, 2].Value = supplier.Name;
                    worksheet.Cells[i + 1, 3].Value = supplier.Email;
                    worksheet.Cells[i + 1, 4].Value = supplier.CountryCode;
                    worksheet.Cells[i + 1, 5].Value = supplier.DateCreated.ToString("yyyy-MMM-dd");
                }
                else if (data is List<DbQuotation>)
                {
                    var quotation = item as DbQuotation;
                    worksheet.Cells[i + 1, 1].Value = quotation.QuotationId;
                    worksheet.Cells[i + 1, 2].Value = quotation.SupplierId;
                    worksheet.Cells[i + 1, 3].Value = quotation.Product;
                    worksheet.Cells[i + 1, 4].Value = quotation.CostPerUnit;
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
