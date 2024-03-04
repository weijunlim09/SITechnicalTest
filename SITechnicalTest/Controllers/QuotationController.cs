using Microsoft.AspNetCore.Mvc;
using SITechnicalTest.Data;
using SITechnicalTest.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SITechnicalTest.Controllers
{
    public class QuotationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuotationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<DbQuotation> quotations = _db.Quotations.ToList();
            quotations = quotations.Where(x => x.CostPerUnit != null).ToList();


            List<IGrouping<int, DbQuotation>> grouped = quotations.GroupBy(x => x.SupplierId).ToList();
            return View(grouped);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<DbSupplier> suppliers = _db.Suppliers.ToList();
            CompositeSupplierQuotation composite = new CompositeSupplierQuotation
            {
                Quotation = new DbQuotation(),
                Suppliers = suppliers
            };
            return View(composite);
        }

        [HttpPost]
        public IActionResult Create(CompositeSupplierQuotation composite)
        {
            List<DbSupplier> suppliers = _db.Suppliers.ToList();
            DbSupplier? supplier = suppliers.FirstOrDefault(x => x.Id == composite.Quotation.SupplierId);
            if (supplier == null)
            {
                ModelState.AddModelError("SupplierId", "Supplier Not Found");
            } else
            {
                composite.Quotation.Supplier = supplier;
                _db.Quotations.Add(composite.Quotation);
                _db.SaveChanges();
                return RedirectToAction("Index", "Quotation");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int? QuotationId)
        {
            if (QuotationId == null | QuotationId <= 0)
            {
                return NotFound();
            }
            List<DbSupplier> suppliers = _db.Suppliers.ToList();
            List<DbQuotation> quotations = _db.Quotations.ToList();

            DbQuotation? q = quotations.Find(x => x.QuotationId == QuotationId);
            CompositeSupplierQuotation composite = new CompositeSupplierQuotation
            {
                Quotation = q,
                Suppliers = suppliers
            };
            return View(composite);
        }


        [HttpPost]
        public IActionResult Update(CompositeSupplierQuotation composite)
        {
            List<DbSupplier> suppliers = _db.Suppliers.ToList();
            DbSupplier? supplier = suppliers.FirstOrDefault(x => x.Id == composite.Quotation.SupplierId);
            if (supplier == null)
            {
                ModelState.AddModelError("SupplierId", "Supplier Not Found");
            }
            else
            {

                _db.Quotations.Update(composite.Quotation);
                _db.SaveChanges();
                return RedirectToAction("Index", "Quotation");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? QuotationId)
        {
            if (QuotationId == null | QuotationId <= 0)
            {
                return NotFound();
            }
            List<DbSupplier> suppliers = _db.Suppliers.ToList();
            List<DbQuotation> quotations = _db.Quotations.ToList();

            DbQuotation? q = quotations.Find(x => x.QuotationId == QuotationId);
            CompositeSupplierQuotation composite = new CompositeSupplierQuotation
            {
                Quotation = q,
                Suppliers = suppliers
            };
            return View(composite);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? QuotationId)
        {
            DbQuotation quotation = _db.Quotations.Find(QuotationId);

            if (quotation == null)
            {
                return NotFound();
            }
            _db.Quotations.Remove(quotation);
            _db.SaveChanges();
            return RedirectToAction("Index", "Quotation");
        }
    }
}
