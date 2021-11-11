using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PQRS.UI.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }
    }
}
