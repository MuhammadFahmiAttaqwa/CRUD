using ApplicationDataKaryawan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApplicationDataKaryawan.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
