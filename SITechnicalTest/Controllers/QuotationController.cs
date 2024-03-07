using Microsoft.AspNetCore.Mvc;

namespace SITechnicalTest.Controllers
{
    public class QuotationController : Controller
    {
        public QuotationController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetByID()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Update(int? QuotationId)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? QuotationId)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? QuotationId)
        {
            return RedirectToAction("Index", "Quotation");
        }
    }
}
