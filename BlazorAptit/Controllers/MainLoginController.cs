using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Controllers
{
    public class MainLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MainLogin()
        {
            return View();
        }
    }
}
