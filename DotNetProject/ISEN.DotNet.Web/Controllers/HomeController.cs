using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISEN.DotNet.Library.Models;

namespace ISEN.DotNet.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? id) {
            ViewData["home-index-id"] = id;
            //ViewData["UserId"]=HttpContext.Session.GetInt32("userId");
            ViewData["UserId"] = HttpContext.Session.GetString("Test");
            return View();
        }
        public IActionResult SetUser(int id) {
            ViewData["UserId"] = id;
            ViewData["session"] = HttpContext.Session.IsAvailable;
            HttpContext.Session.SetString("Test","id");
            return View();
        }
        public IActionResult Error() => View();
    }
}
