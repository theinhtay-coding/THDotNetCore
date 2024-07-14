using Microsoft.AspNetCore.Mvc;

namespace THDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult BasicColumnChart()
        {
            return View();
        }

        public IActionResult ResponsiveChart()
        {
            return View();
        }
    }
}
