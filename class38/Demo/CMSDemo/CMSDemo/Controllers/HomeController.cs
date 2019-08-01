using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSDemo.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMSDemo.Controllers
{
    public class HomeController : Controller
    {
        private IPayment _payment;

        public HomeController(IPayment payment)
        {
            _payment = payment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(bool yes = true)
        {
           string answer = _payment.Run();

            return View();
        }
    }
}