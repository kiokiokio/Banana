using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Banana.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var etsy = new EtsyAPI();
            var result = etsy.GetListings();
            dynamic data = JsonConvert.DeserializeObject("{'Name':'Bob'}");
            var count = data.Name;
            return View();
        }
    }
}