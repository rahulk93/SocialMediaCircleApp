using Microsoft.AspNetCore.Mvc;
using SocialMediaCircleApp.Models;
using System.Diagnostics;

namespace SocialMediaCircleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
