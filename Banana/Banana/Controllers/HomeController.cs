using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banana.Models;

namespace Banana.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Archive()
        {
            ViewData["Message"] = "archive & restore orders";

            return View();
        }

        public IActionResult Sheets()
        {
            ViewData["Message"] = "create and edit export CSVs";

            return View();
        }

        public IActionResult Tracking()
        {
            ViewData["Message"] = "update orders with tracking CSVs";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
