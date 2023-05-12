using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.YouCanList();
            return View(values);
        }
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.YouCanInsert(destination);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDestination(int id)
        {
            return View(_destinationService.YouCanGetById(id));
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.YouCanUpdate(destination);
            return RedirectToAction("Index");
        }
        [HttpGet("~/Admin/Destination/ChangeDestinationStatus/{id}/{destId}")]
        public IActionResult ChangeDestinationStatus(int id,int destId)
        {
            if (id == 1)
            {
                _destinationService.TSetTrueStatus(destId);
            }
            else
            {
                _destinationService.TSetFalseStatus(destId);
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells[1, 1].Value = "Rota";
            worksheet.Cells[1, 2].Value = "Rehber";
            worksheet.Cells[1, 3].Value = "Kontenjan";

            worksheet.Cells[2, 1].Value = "Gürcistan Batum";
            worksheet.Cells[2, 2].Value = "Erkan Bostan";
            worksheet.Cells[2, 3].Value = "50";

            worksheet.Cells[3, 1].Value = "Sırbistan - Makedonya";
            worksheet.Cells[3, 2].Value = "Büşra Hekimoğlu";
            worksheet.Cells[3, 3].Value = "70";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RotaBilgisi.xlsx");
        }
    }
}
