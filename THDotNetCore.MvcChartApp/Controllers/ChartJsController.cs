using Microsoft.AspNetCore.Mvc;

namespace THDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }

        public IActionResult BorderRadiusBarChart()
        {
            return View();
        }

        public IActionResult InterpolationModeLineChart()
        {
            return View();
        }
    }
}
