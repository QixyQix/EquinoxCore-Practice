using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EquinoxCore.Web.Models;

namespace EquinoxCore.Web.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("welcome")]
        [Route("")]
        [Route("/")]
        public IActionResult Index() {
            return View();
        }

        

    }
}
