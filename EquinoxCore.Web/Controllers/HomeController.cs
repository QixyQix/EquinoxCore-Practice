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

        [Route("about")]
        public IActionResult About() {
            ViewData["Message"] = "Your application about page";

            return View();
        }

        [Route("contact")]
        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page";

            return View();
        }

        [Route("error")]
        public IActionResult Error() {
            return View();
        }

        [Route("access-denied")]
        public IActionResult AccessDenied() {
            return View();
        }

    }
}
